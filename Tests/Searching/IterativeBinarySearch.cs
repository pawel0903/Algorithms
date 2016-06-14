using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tests.Searching.Common.Tests;

namespace Tests.Searching
{
    [TestClass]
    public class IterativeBinarySearch
    {
        /// <summary>
        /// Checks if algorithm finds index properly
        /// </summary>
        [TestMethod]
        public void IterativeBinarySearchBasicTest() => SearchBasicTest(Algorithms.Search.Searching.IterativeBinarySearch);

        /// <summary>
        /// Checks if algorithm return -1 if array is empty
        /// </summary>
        [TestMethod]
        public void IterativeBinarySearchEmptyArrayTest() => SearchEmptyArrayTest(Algorithms.Search.Searching.IterativeBinarySearch);

        /// <summary>
        /// Checks if algorithm is O(logn) time complexity
        /// </summary>
        [TestMethod]
        public void IterativeBinarySearchTimeComplexityTest() => SearchTimeComplexityTest(Algorithms.Search.Searching.IterativeBinarySearch, 16, Math.Log(16, 2) + 1);
    }
}
