namespace Sortable_Collection
{
    using System;
    using Sorters;

    public class SortableCollectionPlayground
    {
        private static Random Random = new Random();

        public static void Main(string[] args)
        {
            int[] array1 = { 8, 2, 5, 6, 18, 9, 11, 30, 17, 13, 1, 19, 25 };
            SortableCollection<int> collectionToSort1 = new SortableCollection<int>(array1);
            collectionToSort1.Sort(new HeapSorter<int>());

            Console.WriteLine("Index: " + collectionToSort1.BinarySearch(19, array1));

            const int NumberOfElementsToSort = 20;
            const int MaxValue = 999;

            var array = new int[NumberOfElementsToSort];

            for (int i = 0; i < NumberOfElementsToSort; i++)
            {
                array[i] = Random.Next(MaxValue);
            }

            var collectionToSort = new SortableCollection<int>(array);
            collectionToSort.Sort(new BucketSorter { Max = MaxValue });

            Console.WriteLine("Bucket sort: " + collectionToSort);

            var collection = new SortableCollection<int>(5, -3, 0, 8, -1);
            Console.WriteLine("Collection to sort: " + collection);

            collection.Sort(new Quicksorter<int>());
            Console.WriteLine("Quick sort: " + collection);

            collection.Sort(new HeapSorter<int>());
            Console.WriteLine("Heap sort: " + collection);

            collection.Sort(new InsertionSorter<int>());
            Console.WriteLine("Insertion sort: " + collection);

            collection.Sort(new MergeSorter<int>());
            Console.WriteLine("Merge sort: " + collection);

            collection.Sort(new InPlaceMergeSorter<int>());
            Console.WriteLine("InPlaceMerge sort: " + collection);
        }
    }
}
