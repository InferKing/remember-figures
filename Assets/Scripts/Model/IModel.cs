using System;

namespace Model
{
	public interface IModel
	{
        byte Row { get; }
        byte Column { get; }
        Cell[,] Table { get; }
        event Action WrongMove;
        event Action CorrectMove;
        void Move(byte row, byte column);
    } 
}
