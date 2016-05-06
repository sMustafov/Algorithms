namespace Problem2.ModifiedKruskalAlgorithm
{
    using System;
    
    public class Edge : IComparable<Edge>
    {
        public Edge(int parent, int child, int weight)
        {
            this.Parent = parent;
            this.Child = child;
            this.Weight = weight;
        }

        public int Parent { get; set; }

        public int Child { get; set; }

        public int Weight { get; set; }

        public int CompareTo(Edge other)
        {
            int weightCompared = this.Weight.CompareTo(other.Weight);

            return weightCompared;
        }

        public override string ToString()
        {
            return string.Format("({0} {1}) -> {2}", this.Parent, this.Child, this.Weight);
        }
    }
}