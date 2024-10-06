using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Model
{
    public class GameModel
    {
        public event Action WrongMove;
        public event Action CorrectMove;

        private Cell[,] _table;
        private List<short> _picked;
        private short _currentOrder = 0;

        public GameModel(GameSettings settings)
        {
            InitPicked(settings);
            InitTable(settings);
        }

        public void Move(int row, int column)
        {
            if (_currentOrder != _table[row, column].order)
            {
                WrongMove?.Invoke();
            }
            else
            {
                _currentOrder += 1;
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
            _table = new Cell[settings.Rows, settings.Columns];
            for (byte i = 0; i < _table.GetLength(0); i++)
            {
                short columns = (short)_table.GetLength(1);
                for (byte j = 0; j < columns; j++)
                {
                    _table[i, j] = new Cell(i, j, GetRandomValue(), (short)(i * columns + j));
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