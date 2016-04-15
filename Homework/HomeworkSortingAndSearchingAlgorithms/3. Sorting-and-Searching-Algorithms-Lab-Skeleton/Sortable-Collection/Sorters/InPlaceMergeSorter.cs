namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class InPlaceMergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            this.InPlaceMergeSort(collection, 0, collection.Count);
        }

        private void InPlaceMergeSort(List<T> collection, int start, int end)
        {
            if (end - start > 1)
            {
                int mid = start + ((end - start) / 2);
                int workingStart = start + end - mid;

                this.SortWorkingArea(collection, start, mid, workingStart);

                while (workingStart - start > 2)
                {
                    int workingStart1 = workingStart;
                    workingStart = start + (workingStart1 - start + 1) / 2;

                    this.SortWorkingArea(collection, workingStart, workingStart1, start);
                    this.Merge(collection, start, start + workingStart1 - workingStart, workingStart1, end, workingStart);
                }

                for (int mainElement = workingStart; mainElement > start; mainElement--)
                {
                    for (int subElement = mainElement; subElement < end && collection[subElement].CompareTo(collection[subElement - 1]) < 0; subElement++)
                    {
                        Swap(collection, subElement, subElement - 1);
                    }
                }
            }
        }

        private void SortWorkingArea(List<T> collection, int start, int end, int workingStart)
        {
            if (end - start > 1)
            {
                int mid = start + ((end - start) / 2);

                this.InPlaceMergeSort(collection, start, mid);
                this.InPlaceMergeSort(collection, mid, end);

                this.Merge(collection, start, mid, mid, end, workingStart);
            }
        }

        private void Merge(List<T> collection, int start, int end, int start1, int end1, int workingStart)
        {
            while (start < end && start1 < end1)
            {
                Swap(collection, workingStart++, collection[start].CompareTo(collection[start1]) <= 0 ? start++ : start1++);
            }

            while (start < end)
            {
                Swap(collection, workingStart++, start++);
            }

            while (start1 < end1)
            {
                Swap(collection, workingStart++, start1++);
            }
        }

        private void Swap(List<T> collection, int a, int b)
        {
            var temp = collection[a];
            collection[a] = collection[b];
            collection[b] = temp;
        }
    }
}
