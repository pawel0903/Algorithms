using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Algorithms.Common.Utils;

namespace Algorithms.Sorting
{
    public static partial class Sorting
    {
        /// <summary>
        /// Core of recursive Quicksort algorithm - uses Hoare partition
        /// </summary>
        /// <typeparam name="T">Type - must implement IComparable<T></typeparam>
        /// <param name="array">Collection to be sorted</param>
        private static void RecursiveQuickSort<T>(T[] array, int lo, int hi) where T : IComparable<T>
        {
            if (lo < hi)
            {
                int partition = HoarePartition(array, lo, hi);
                // in case of Lomuto partion use: 
                // RecursiveQuickSort(array, lo, partition + 1) for left
                RecursiveQuickSort(array, lo, partition);
                RecursiveQuickSort(array, partition + 1, hi);
            }
        }

        /// <summary>
        /// Recursive Quicksort algorithm - uses Hoare partition
        /// Time Complexity: 
        /// Worst case - O(n^2)
        /// Best case - O(n log n)
        /// Average - O(n log n)
        /// Auxilary space: O(n)
        /// </summary>
        /// <typeparam name="T">Type - must implement IComparable<T></typeparam>
        /// <param name="array">Collection to be sorted</param>
        public static void RecursiveQuickSort<T>(this T[] array) where T : IComparable<T>
        {
            RecursiveQuickSort(array, 0, array.Length - 1);
        }
    }
}
