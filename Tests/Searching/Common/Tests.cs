using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.TestStructures;

namespace Tests.Searching.Common
{
    public static class Tests
    {
        /// <summary>
        /// Checks if algorithm finds index properly
        /// </summary>
        public static void SearchBasicTest(Func<int[], int, int, int, int> search)
        {
            int[] values = { 1, 2, 3, 8, 23, 74, 107, 342 };

            foreach (int value in values)
            {
                Assert.AreEqual(value, values[search(values, value, 0, values.Length - 1)]);
            }

            Assert.AreEqual(-1, search(values, 55, 0, values.Length - 1));
            Assert.AreEqual(-1, search(values, 0, 0, values.Length - 1));
            Assert.AreEqual(-1, search(values, 376, 0, values.Length - 1));
        }

        /// <summary>
        /// Checks if algorithm return -1 if array is empty
        /// </summary>
        public static void SearchEmptyArrayTest(Func<int[], int, int, int, int> search)
        {
            Assert.AreEqual(-1, search(new int[] { }, 55, 0, (new int[] { }).Length - 1));
        }

        /// <summary>
        /// Checks if algorithm is <= maxTime time complexity
        /// </summary>
        public static void SearchTimeComplexityTest(Func<Item<int>[], Item<int>, int, int, int> search, int n, double maxTime)
        {
            List<Item<int>> list = new List<Item<int>>();
            for (int i = 0; i < n; i++)
            {
                list.Add(new Item<int>(i + 1));
            }
            Item<int>[] values = list.ToArray();

            search(values, new Item<int>(n + 5), 0, values.Length - 1);
            Assert.IsTrue(Item<int>.TimeComplexity(values) <= maxTime);
        }
    }
}
