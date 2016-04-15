namespace Problem7.ConnectedAreasInAMatrix
{
    using System;

    public class ConnectedArea : IComparable<ConnectedArea>
    {
        public ConnectedArea(int size, int row, int col)
        {
            this.Row = row;
            this.Col = col;
            this.Size = size;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public int Size { get; set; }

        public int CompareTo(ConnectedArea other)
        {
            if (this.Size.CompareTo(other.Size) != 0)
            {
                return -this.Size.CompareTo(other.Size);
            }

            if (this.Row.CompareTo(other.Row) != 0)
            {
                return this.Row.CompareTo(other.Row);
            }

            return this.Col.CompareTo(other.Col);
        }

        public override string ToString()
        {
            return string.Format(
                "({0}, {1}), size: {2}",
                this.Row,
                this.Col,
                this.Size);
        }
    }
}