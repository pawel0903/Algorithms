using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Sorting;

namespace Tests.Sorting
{
    [TestClass]
    public class MergeSort
    {
        [TestMethod]
        public void MergeSorttBasicTest()
        {
            int[] ints = { 10, 45, 15, 39, 21, 26, 38 };
            int[] copy = ints.Clone() as int[];
            ints.MergeSort();
            Array.Sort(copy);

            for (int i = 0; i < ints.Length; i++)
            {
                Assert.AreEqual(ints[i], copy[i]);
            }
        }
    }
}
