namespace Model
{
    public class Cell
    {
        public readonly byte row;
        public readonly byte col;
        public readonly short value;

        public bool isShowed;
        public bool isLocked;

        public Cell(byte row, byte col, short value)
        {
            this.row = row;
            this.col = col;
            this.value = value;
            isLocked = false;
            isShowed = false;
        }
    }
}
