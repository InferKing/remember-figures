namespace Model
{
    public class Cell
    {
        public readonly byte row;
        public readonly byte col;
        public readonly short value;
        public bool showed;
        public bool locked;
        public Cell(byte row, byte col, short value)
        {
            this.row = row;
            this.col = col;
            this.value = value;
            locked = false;
            showed = false;
        }
    }
}
