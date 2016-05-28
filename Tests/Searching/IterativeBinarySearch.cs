using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Tests.TestStructures;
using static Algorithms.Search.IterativeBinarySearch;

namespace Tests.Searching
{
    [TestClass]
    public class IterativeBinarySearch
    {
        /// <summary>
        /// Checks if algorithm finds index properly
        /// </summary>
        [TestMethod]
        public void IterativeBinarySearchBasicTest()
        {
            int[] values = { 1, 2, 3, 8, 23, 74, 107, 342 };

            foreach (int value in values)
            {
                Assert.AreEqual(value, values[Search(values, value, 0, values.Length - 1)]);
            }

            Assert.AreEqual(-1, Search(values, 55, 0, values.Length - 1));
            Assert.AreEqual(-1, Search(values, 0, 0, values.Length - 1));
            Assert.AreEqual(-1, Search(values, 376, 0, values.Length - 1));
        }

        /// <summary>
        /// Checks if algorithm return -1 if array is empty
        /// </summary>
        [TestMethod]
        public void IterativeBinarySearchEmptyArrayTest()
        {
            Assert.AreEqual(-1, Search(new int[] { }, 55, 0, (new int[] { }).Length - 1));
        }

        /// <summary>
        /// Checks if algorithm is O(logn) time complexity
        /// </summary>
        [TestMethod]
        public void IterativeBinarySearchTimeComplexityTest()
        {
            List<Item<int>> list = new List<Item<int>>();
            for (int i = 0; i < 16; i++)
            {
                list.Add(new Item<int>(i + 1));
            }
            Item<int>[] values = list.ToArray();

            Search(values, new Item<int>(24), 0, values.Length - 1);
            Assert.IsTrue(Item<int>.TimeComplexity(values) <= Math.Log(values.Length, 2) + 1);
        }
    }
}
