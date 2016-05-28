using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Tests.TestStructures;
using static Algorithms.Search.LinearSearch;

namespace Tests.Searching
{
    [TestClass]
    public class LinearSearch
    {
        /// <summary>
        /// Checks if algorithm finds index properly
        /// </summary>
        [TestMethod]
        public void LinearSearchBasicTest()
        {
            int[] values = { 1, 2, 3, 8, 23, 74, 107, 342 };

            foreach (int value in values)
            {
                Assert.AreEqual(value, values[Search(values, value)]);
            }

            Assert.AreEqual(-1, Search<int>(values, 55));
        }

        /// <summary>
        /// Checks if algorithm return -1 if array is empty
        /// </summary>
        [TestMethod]
        public void LinearSearchEmptyArrayTest()
        {
            Assert.AreEqual(-1, Search(new int[] { }, 55));
        }

        /// <summary>
        /// Checks if algorithm is O(n) time complexity
        /// </summary>
        [TestMethod]
        public void LinearSearchTimeComplexityTest()
        {
            List<Item<int>> list = new List<Item<int>>();
            for (int i = 0; i < 16; i++)
            {
                list.Add(new Item<int>(i + 1));
            }
            Item<int>[] values = list.ToArray();

            Search(values, new Item<int>(16));
            Assert.IsTrue(Item<int>.TimeComplexity(values) <= values.Length);
        }
    }
}
