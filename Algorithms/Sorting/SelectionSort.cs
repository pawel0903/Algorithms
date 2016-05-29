using System;
using Algorithms.Common;

namespace Algorithms.Sorting
{
    public static class SelectionSort
    {
        /// <summary>
        /// Selection sort
        /// Time Complexity: O(n^2)
        /// Auxilary space: O(1)
        /// </summary>
        /// <typeparam name="T">Type - must implement IComparable<T></typeparam>
        /// <param name="array">Collection to be sorted</param>
        public static void Sort<T>(this T[] array) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length; i++)
            {
                int min = i;
                for (int j = i; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[min]) < 0)
                        min = j;
                }
                Utils.Swap(ref array[i], ref array[min]);
            }
        }
    }
}
