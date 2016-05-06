namespace Problem2.ProcessorScheduling
{
    using System;

    public class Task : IComparable<Task>
    {
        public Task(int number, int value, int deadline)
        {
            this.Number = number;
            this.Value = value;
            this.Deadline = deadline;
        }

        public int Number { get; set; }

        public int Value { get; set; }

        public int Deadline { get; set; }

        public int CompareTo(Task other)
        {
            return this.Value.CompareTo(other.Value);
        }
    }
}