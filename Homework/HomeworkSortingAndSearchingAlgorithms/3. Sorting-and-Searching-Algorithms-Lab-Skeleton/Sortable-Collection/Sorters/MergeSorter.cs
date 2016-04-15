namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            var tempArray = new T[collection.Count];
            this.MergeSort(collection, tempArray, 0, collection.Count - 1);
        }

        private void MergeSort(List<T> array, T[] temporaryArray, int start, int end)
        {
            if (start < end)
            {
                int middle = (start + end) / 2;

                MergeSort(array, temporaryArray, start, middle);
                MergeSort(array, temporaryArray, middle + 1, end);

                Merge(array, temporaryArray, start, middle, end);
            }
        }

        private void Merge(List<T> array, T[] temporaryArray, int start, int middle, int end)
        {
            int leftStart = start;
            int rightStart = middle + 1;
            int tempIndex = 0;

            while (leftStart <= middle && rightStart <= end)
            {
                if (array[leftStart].CompareTo(array[rightStart]) <= 0)
                {
                    temporaryArray[tempIndex++] = array[leftStart++];
                }
                else
                {
                    temporaryArray[tempIndex++] = array[rightStart++];
                }
            }

            while (leftStart <= middle)
            {
                temporaryArray[tempIndex++] = array[leftStart++];
            }

            while (rightStart <= end)
            {
                temporaryArray[tempIndex++] = array[rightStart++];
            }

            leftStart = start;
            tempIndex = 0;

            while (tempIndex < temporaryArray.Length && leftStart <= end)
            {
                array[leftStart] = temporaryArray[tempIndex];
                leftStart++;
                tempIndex++;
            }
        }
    }
}
