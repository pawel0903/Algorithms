using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Sorting;

namespace Tests.Sorting
{
    [TestClass]
    public class RecursiveQuickSort
    {
        [TestMethod]
        public void RecursiveQuickSortBasicTest()
        {
            int[] ints = { 10, 45, 15, 39, 21, 26, 38, 40, 39, 40 };
            int[] copy = ints.Clone() as int[];

            ints.RecursiveQuickSort();
            Array.Sort(copy);

            for (int i = 0; i < ints.Length; i++)
            {
                Assert.AreEqual(ints[i], copy[i]);
            }
        }
    }
}
