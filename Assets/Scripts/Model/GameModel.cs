using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class GameModel : IModel
    {
        public event Action<Cell> WrongMove;
        public event Action<Cell> CorrectMove;
        public event Action EndOfGame;
        public byte Row { get; }
        public byte Column { get; }
        public Cell ActiveCell { get; protected set; }
        public Cell[,] Table { get; protected set; }
        private List<short> _picked;
        private short _currentOrder = 1;

        public GameModel(GameSettings settings)
        {
            Row = settings.Rows;
            Column = settings.Columns;

            InitPicked(settings);
            InitTable(settings);
        }

        public void Move(byte row, byte column)
        {
            var currentCell = Table[row, column];

            if (currentCell != ActiveCell && ActiveCell != null)
            {
                return;
            }

            if (_currentOrder != currentCell.value)
            {
                ActiveCell = currentCell.showed ? null : currentCell;
                WrongMove?.Invoke(currentCell);
            }
            else
            {
                _currentOrder += 1;
                currentCell.locked = true;
                CorrectMove?.Invoke(currentCell);
                ActiveCell = null;

                if (_currentOrder - 1 == Row * Column)
                {
                    EndOfGame?.Invoke();
                }
            }
            currentCell.showed = !currentCell.showed;
        }

        private void InitPicked(GameSettings settings)
        {
            _picked = new();
            for (short i = 0; i < settings.Rows * settings.Columns; i++)
            {
                _picked.Add((short)(i + 1));
            }
            // need to shuffle list before using
            Random rand = new();
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
                    Table[i, j] = new Cell(i, j, GetRandomValue());
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