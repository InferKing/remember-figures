namespace Model
{
    public class Cell
    {
        public Cell(int row, int column, int value)
        {
            Row = row;
            Column = column;
            Value = value;
            IsShowed = false;
            IsLocked = false;
        }

        public int Row { get; }
        public int Column { get; }
        public int Value { get; }

        public bool IsShowed { get; set; }
        public bool IsLocked { get; set; }
    }
}
