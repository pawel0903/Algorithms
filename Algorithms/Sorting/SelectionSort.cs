using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    public static class SelectionSort
    {
        /// <summary>
        /// Swap helper function
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="left">first argument</param>
        /// <param name="right">second argument</param>
        private static void Swap<T>(ref T left, ref T right)
        {
            T tmp = left;
            left = right;
            right = tmp;
        }

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
                Swap(ref array[i], ref array[min]);
            }
        }
    }
}
