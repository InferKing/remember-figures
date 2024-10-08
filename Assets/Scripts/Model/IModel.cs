using System;

namespace Model
{
	public interface IModel
	{
        byte Row { get; }
        byte Column { get; }
        Cell[,] Table { get; }
        Cell ActiveCell { get; }
        event Action<Cell> WrongMove;
        event Action<Cell> CorrectMove;
        event Action EndOfGame;
        void Move(byte row, byte column);
    } 
}
