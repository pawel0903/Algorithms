using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Tests.TestStructures;
using static Tests.Searching.Common.Tests;

namespace Tests.Searching
{
    [TestClass]
    public class LinearSearch
    {
        /// <summary>
        /// Checks if algorithm finds index properly
        /// </summary>
        [TestMethod]
        public void LinearSearchBasicTest() => SearchBasicTest(Algorithms.Search.Searching.LinearSearch);

        /// <summary>
        /// Checks if algorithm return -1 if array is empty
        /// </summary>
        [TestMethod]
        public void LinearSearchEmptyArrayTest() => SearchEmptyArrayTest(Algorithms.Search.Searching.LinearSearch);

        /// <summary>
        /// Checks if algorithm is O(n) time complexity
        /// </summary>
        [TestMethod]
        public void LinearSearchTimeComplexityTest() => SearchTimeComplexityTest(Algorithms.Search.Searching.LinearSearch, 16, 16);
    }
}
