namespace Problem3.MostReliablePath
{
    using System;
    using System.Collections.Generic;

    public class Node : IComparable<Node>
    {
        public Node(int value, double reliability)
        {
            this.Value = value;
            this.Edges = new List<Edge>();
            this.Reliability = reliability;
        }

        public int Value { get; set; }

        public double Reliability { get; set; }

        public List<Edge> Edges { get; private set; }

        public int CompareTo(Node other)
        {
            return this.Reliability.CompareTo(other.Reliability);
        }
    }
}