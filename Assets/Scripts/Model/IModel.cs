using System;

namespace Model
{
    public interface IModel
    {
        int Row { get; }
        int Column { get; }
        Cell[,] Table { get; }
        Cell ActiveCell { get; }

        event Action<Cell> WrongMove;
        event Action<Cell> CorrectMove;
        event Action EndOfGame;

        void Move(int row, int column);
    }
}
