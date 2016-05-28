using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Searching.Structures;
using System.Collections.Generic;

namespace Tests.Searching
{
    [TestClass]
    public class LinearSearch
    {
        /// <summary>
        /// Checks if algorithm finds index properly
        /// </summary>
        [TestMethod]
        public void BasicTest()
        {
            int[] values = { 1, 2, 3, 8, 23, 74, 107, 342 };

            for (int i = 0; i < values.Length; i++)
            {
                Assert.AreEqual(values[i], values[Algorithms.Search.LinearSearch.Search<int>(values, values[i])]);
            }

            Assert.AreEqual(-1, Algorithms.Search.LinearSearch.Search<int>(values, 55));
        }

        /// <summary>
        /// Checks if algorithm return -1 if array is empty
        /// </summary>
        [TestMethod]
        public void EmptyArrayTest()
        {
            int[] values = { };

            Assert.AreEqual(-1, Algorithms.Search.LinearSearch.Search<int>(values, 55));
        }

        /// <summary>
        /// Checks if algorithm finds index properly
        /// </summary>
        [TestMethod]
        public void TimeComplexityTest()
        {
            List<Item<int>> list = new List<Item<int>>();
            for (int i = 0; i < 16; i++)
            {
                list.Add(new Item<int>(i + 1));
            }
            Item<int>[] values = list.ToArray();

            Algorithms.Search.LinearSearch.Search<Item<int>>(values, new Item<int>(16));
            Assert.IsTrue(condition: Item<int>.TimeComplexity(values) <= values.Length);
        }
    }
}
