using System;
using static Algorithms.Common.Utils;

namespace Algorithms.Sorting
{
    public static partial class Sorting
    {
        /// <summary>
        /// Bubble sort - optimized version(breaks when the array is alrady sorted)
        /// Time Complexity: 
        /// Worst case - O(n^2)
        /// Best case - O(n)
        /// Average - O(n^2)
        /// Auxilary space: O(1)
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="array">Collection to be sorted</param>
        public static void BubbleSort<T>(this T[] array) where T : IComparable<T>
        {
            for (int i = 1; i < array.Length; i++)
            {
                int noOfSwaps = 0;
                for (int j = i; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[j - 1]) < 0)
                    {
                        Swap(ref array[j], ref array[j - 1]);
                        noOfSwaps++;
                    }
                }
                if (noOfSwaps == 0)
                    return;
            }
        }
    }
}
