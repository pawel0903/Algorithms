using System;

namespace Algorithms.Sorting
{
    public static partial class Sorting
    {
        /// <summary>
        /// Insertion sort
        /// Time Complexity: 
        /// Worst case - O(n^2)
        /// Best case - O(n)
        /// Average - O(n^2)
        /// Auxilary space: O(1)
        /// </summary>
        /// <typeparam name="T">Type - must implement IComparable<T></typeparam>
        /// <param name="array">Collection to be sorted</param>
        public static void InsertionSort<T>(this T[] array) where T : IComparable<T>
        {
            for (int i = 1; i < array.Length; i++)
            {
                T key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j].CompareTo(key) > 0)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j+1] = key;
            }
        }
    }
}
