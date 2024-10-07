namespace Model
{
    public class Cell
    {
        public readonly byte row;
        public readonly byte col;
        public readonly short value;
        public readonly short order;
        public bool locked;
        public Cell(byte row, byte col, short value, short order)
        {
            this.row = row;
            this.col = col;
            this.value = value;
            this.order = order;
            locked = false;
        }
    }
}
