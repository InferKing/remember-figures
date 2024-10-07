using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class GameModel : IModel
    {
        public event Action WrongMove;
        public event Action CorrectMove;
        public byte Row { get; }
        public byte Column { get; }

        public Cell[,] Table { get; protected set; }
        private List<short> _picked;
        private short _currentOrder = 0;

        public GameModel(GameSettings settings)
        {
            Row = settings.Rows;
            Column = settings.Columns;

            InitPicked(settings);
            InitTable(settings);
        }

        public void Move(byte row, byte column)
        {
            if (_currentOrder != Table[row, column].order)
            {
                WrongMove?.Invoke();
            }
            else
            {
                _currentOrder += 1;
                Table[row, column].locked = true;
                CorrectMove?.Invoke();
            }
        }

        private void InitPicked(GameSettings settings)
        {
            _picked = new();
            for (short i = 0; i < settings.Rows * settings.Columns; i++)
            {
                _picked.Add((short)(i + 1));
            }
            // need to shuffle list before using
            System.Random rand = new();
            _picked = _picked.OrderBy(x => rand.Next()).ToList();
        }

        private void InitTable(GameSettings settings)
        {
            Table = new Cell[settings.Rows, settings.Columns];
            for (byte i = 0; i < Table.GetLength(0); i++)
            {
                short columns = (short)Table.GetLength(1);
                for (byte j = 0; j < columns; j++)
                {
                    Table[i, j] = new Cell(i, j, GetRandomValue(), (short)(i * columns + j));
                }
            }
        }

        private short GetRandomValue()
        {
            short pickedValue = _picked[0];
            _picked.RemoveAt(0);
            return pickedValue;
        }
    }
}