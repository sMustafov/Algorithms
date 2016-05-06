namespace Problem1.FractionalKnapsackProblem
{
    using System;

    public class Item : IComparable<Item>
    {
        public Item(int price, int weight)
        {
            this.Price = price;
            this.Weight = weight;
            this.Average = price/(double) weight;
        }

        public int Price { get; set; }

        public int Weight { get; set; }

        public double Average { get; set; }

        public int CompareTo(Item other)
        {
            return this.Average.CompareTo(other.Average);
        }
    }
}