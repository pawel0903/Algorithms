using System;
using System.Linq;

namespace Algorithms.Sorting
{
    public static partial class Sorting
    {
        /// <summary>
        /// Merge function
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="array">Collection</param>
        /// <param name="l">left index</param>
        /// <param name="m">middle index</param>
        /// <param name="r">right index</param>
        private static void Merge<T>(T[] array, int l, int m, int r) where T : IComparable<T>
        {
            T[] tmpL = array.Skip(l).Take(m - l + 1).ToArray();
            T[] tmpR = array.Skip(m+1).Take(r - m).ToArray();

            int leftIndex = 0;
            int rightIndex = 0;
            int index = l;

            while (leftIndex < tmpL.Length && rightIndex < tmpR.Length)
            {
                array[index++] = tmpL[leftIndex].CompareTo(tmpR[rightIndex]) < 0 ? tmpL[leftIndex++] : tmpR[rightIndex++];
            }

            while (leftIndex < tmpL.Length)
            {
                array[index++] = tmpL[leftIndex++];
            }

            while (rightIndex < tmpR.Length)
            {
                array[index++] = tmpR[rightIndex++];
            }
        }

        /// <summary>
        /// Core of MergeSort algorithm
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="array">Collection</param>
        /// <param name="l">left index</param>
        /// <param name="r">right index</param>
        private static void MergeSort<T>(T[] array, int l, int r) where T : IComparable<T>
        {
            if (l == r)
                return;

            int middle = (l + r)/2;
            MergeSort(array, l, middle);
            MergeSort(array, middle + 1, r);
            Merge(array, l, middle, r);
        }


        /// <summary>
        /// Merge sort
        /// Time Complexity: 
        /// Worst case - O(n log n)
        /// Best case - O(n log n)
        /// Average - O(n log n)
        /// Auxilary space: O(n)
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="array">Collection to be sorted</param>
        public static void MergeSort<T>(this T[] array) where T : IComparable<T>
        {
            MergeSort(array, 0, array.Length);
        }
    }
}
