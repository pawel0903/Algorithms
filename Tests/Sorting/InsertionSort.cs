using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Sorting;

namespace Tests.Sorting
{
    [TestClass]
    public class InsertionSort
    {
        [TestMethod]
        public void InsertionSortBasicTest()
        {
            int[] ints = { 10, 45, 15, 39, 21, 26 };
            int[] copy = ints.Clone() as int[];
            ints.InsertionSort();
            Array.Sort(copy);

            for (int i = 0; i < ints.Length; i++)
            {
                Assert.AreEqual(ints[i], copy[i]);
            }
        }
    }
}
