

namespace Sortable_Collection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Sorters;

    public class SortableCollection<T> where T : IComparable<T>
    {
        public SortableCollection()
        {
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public SortableCollection(params T[] items)
            : this(items.AsEnumerable())
        {
        }

        public List<T> Items { get; set; }

        public int Count
        {
            get
            {
                return this.Items.Count;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int BinarySearch(T item, T[] array)
        {
            int start = 0;
            int end = this.Items.Count - 1;

            int steps = 0;

            while (start <= end)
            {
                int middle = (start + end) / 2;
                if (item.CompareTo(this.Items[middle]) < 0)
                {
                    start = middle + 1;
                    steps++;
                }
                else if (item.CompareTo(this.Items[middle]) > 0)
                {
                    start = middle - 1;
                    steps++;
                }
                else
                {
                    Console.WriteLine("Found in {0} steps", steps);
                    return middle;
                }
            }

            return -1;
        }

        public int InterpolationSearch(int key, int[] sortedArray)
        {
            InsertionSorter<int> sorter = new InsertionSorter<int>();
            sorter.Sort(sortedArray.ToList());

            int low = 0;
            int high = sortedArray.Length - 1;

            while (sortedArray[low] <= key && sortedArray[high] >= key)
            {
                int mid = low + ((key - sortedArray[low]) * (high - low)) / (sortedArray[high] - sortedArray[low]);

                if (sortedArray[mid] < key)
                {
                    low = mid + 1;
                }
                else if (sortedArray[mid] > key)
                {
                    high = mid - 1;
                }
                else
                {
                    return mid;
                }
            }

            if (sortedArray[low] == key)
            {
                return low;
            }
            else
            {
                Console.WriteLine("Key not found");
                return 0;
            }
        }

        public IEnumerable<T> Shuffle<T>(IEnumerable<T> source)
        {
            Random rnd = new Random();
            var array = source.ToArray();
            var n = array.Length;

            for (int i = 0; i < n; i++)
            {
                int r = i + rnd.Next(0, n - i);
                var temp = array[i];
                array[i] = array[r];
                array[r] = temp;
            }

            return array;
        }

        public T[] ToArray()
        {
            return this.Items.ToArray();
        }

        public override string ToString()
        {
            return string.Format(string.Join(", ", this.Items));
        }
    }
}