﻿namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class HeapSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            var heap = new BinaryHeap<T>(collection);
            for (int i = 0; i < collection.Count; i++)
            {
                collection[i] = heap.ExtractMin();
            }
        }
    }
}
