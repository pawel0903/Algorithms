using System;

namespace Algorithms.Search
{
    public static class RecursiveBinarySearch
    {
        /// <summary>
        /// Recursive binary search
        /// Time complexity = O(logn)
        /// </summary>
        /// <typeparam name="T">Type - must implement IComparable<T></typeparam>
        /// <param name="collection">Collection of elements</param>
        /// <param name="value">Value to be found</param>
        /// <param name="left">left index</param>
        /// <param name="right">right index</param>
        /// <returns>If value is present in collection return its location, otherwise return -1</returns>
        public static int Search<T>(T[] collection, T value, int left, int right) where T : IComparable<T>
        {
            if (left <= right)
            {
                int middle = (left + right) / 2;
                int compareResult = collection[middle].CompareTo(value);

                if (compareResult == 0)
                    return middle;

                if (compareResult > 0)
                    return Search(collection, value, left, middle - 1);
                else
                    return Search(collection, value, middle + 1, right);
            }

            return -1;
        }
    }
}
