using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class GameModel : IModel
    {
        private List<int> _pickedCells;
        private int _currentOrder = 1;

        public GameModel(GameConfig settings)
        {
            Row = settings.Rows;
            Column = settings.Columns;

            InitPicked(settings);
            InitTable(settings);
        }

        public int Row { get; }
        public int Column { get; }

        public Cell ActiveCell { get; protected set; }
        public Cell[,] Table { get; protected set; }

        public event Action<Cell> WrongMove;
        public event Action<Cell> CorrectMove;
        public event Action EndOfGame;

        public void Move(int row, int column)
        {
            var currentCell = Table[row, column];

            if (currentCell != ActiveCell && ActiveCell != null)
            {
                return;
            }

            if (_currentOrder != currentCell.Value)
            {
                ActiveCell = currentCell.IsShowed ? null : currentCell;
                WrongMove?.Invoke(currentCell);
            }
            else
            {
                _currentOrder += 1;
                currentCell.IsLocked = true;

                CorrectMove?.Invoke(currentCell);
                ActiveCell = null;

                if (_currentOrder - 1 == Row * Column)
                {
                    EndOfGame?.Invoke();
                }
            }

            currentCell.IsShowed = !currentCell.IsShowed;
        }

        private void InitPicked(GameConfig settings)
        {
            _pickedCells = new();

            for (int i = 0; i < settings.Rows * settings.Columns; i++)
            {
                _pickedCells.Add(i + 1);
            }

            ShuffleCells();
        }

        private void ShuffleCells()
        {
            Random rand = new();
            _pickedCells = _pickedCells.OrderBy(x => rand.Next()).ToList();
        }

        private void InitTable(GameConfig settings)
        {
            Table = new Cell[settings.Rows, settings.Columns];

            for (int i = 0; i < Table.GetLength(0); i++)
            {
                int columns = Table.GetLength(1);

                for (int j = 0; j < columns; j++)
                {
                    Table[i, j] = new Cell(i, j, GetAndRemoveFirstCell());
                }
            }
        }

        private int GetAndRemoveFirstCell()
        {
            int pickedValue = _pickedCells[0];
            _pickedCells.RemoveAt(0);
            return pickedValue;
        }
    }
}