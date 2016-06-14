using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Sorting.Common
{
    public static class Tests
    {
        public static void BasicSortingTest(Action<int[]> sort)
        {
            int[] ints = { 10, 45, 15, 39, 21, 26, 38, 40, 39, 40 };
            int[] copy = ints.Clone() as int[];

            sort(ints);
            Array.Sort(copy);

            for (int i = 0; i < ints.Length; i++)
            {
                Assert.AreEqual(ints[i], copy[i]);
            }
        }
    }
}
