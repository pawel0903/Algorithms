using System;

namespace Algorithms.Search
{
    public static partial class Searching
    {
        /// <summary>
        /// Basic linear search
        /// Time complexity = O(n)
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="collection">Collection of elements</param>
        /// <param name="value">Value to be found</param>
        /// <param name="left">left index</param>
        /// <param name="right">right index</param>
        /// <returns>If value is present in collection return its location, otherwise return -1</returns>
        public static int LinearSearch<T>(T[] collection, T value, int left, int right) where T : IComparable<T>
        {
            for (int i = left; i <= right; i++)
            {
                if (collection[i].CompareTo(value) == 0)
                    return i;
            }
            return -1;
        }
    }
}
