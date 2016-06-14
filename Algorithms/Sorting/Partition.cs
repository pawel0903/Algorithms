using System;
using static Algorithms.Common.Utils;

namespace Algorithms.Sorting
{
    public static partial class Sorting
    {
        /// <summary>
        /// Lomuto partition - picks hi element as pivot
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="array">collection of objects</param>
        /// <param name="lo">lower end</param>
        /// <param name="hi">higher end</param>
        private static int LomutoPartition<T>(T[] array, int lo, int hi) where T : IComparable<T>
        {
            T pivot = array[hi];
            int i = lo;

            for (int j = lo; j <= hi - 1; j++)
            {
                if (array[j].CompareTo(pivot) <= 0)
                {
                    Swap(ref array[i], ref array[j]);
                    i++;
                }
            }

            Swap(ref array[i], ref array[hi]);

            return i;
        }

        /// <summary>
        /// Hoare partition - picks lo as pivot
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="array">collection of objects</param>
        /// <param name="lo">lower end</param>
        /// <param name="hi">higher end</param>
        private static int HoarePartition<T>(T[] array, int lo, int hi) where T : IComparable<T>
        {
            T pivot = array[lo];
            int i = lo - 1;
            int j = hi + 1;

            while (true)
            {
                do
                {
                    i++;
                } while (array[i].CompareTo(pivot) < 0);

                do
                {
                    j--;
                } while (array[j].CompareTo(pivot) > 0);

                if (i >= j)
                    return j;

                Swap(ref array[i], ref array[j]);
            }
        }
    }
}
