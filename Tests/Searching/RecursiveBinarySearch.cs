using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tests.Searching.Common.Tests;

namespace Tests.Searching
{
    [TestClass]
    public class RecursiveBinarySearch
    {
        /// <summary>
        /// Checks if algorithm finds index properly
        /// </summary>
        [TestMethod]
        public void RecursiveBinarySearchBasicTest() => SearchBasicTest(Algorithms.Search.Searching.RecursiveBinarySearch);

        /// <summary>
        /// Checks if algorithm return -1 if array is empty
        /// </summary>
        [TestMethod]
        public void RecursiveBinarySearchEmptyArrayTest() => SearchEmptyArrayTest(Algorithms.Search.Searching.RecursiveBinarySearch);

        /// <summary>
        /// Checks if algorithm is O(logn) time complexity
        /// </summary>
        [TestMethod]
        public void RecursiveBinarySearchTimeComplexityTest() => SearchTimeComplexityTest(Algorithms.Search.Searching.RecursiveBinarySearch, 16, Math.Log(16, 2) + 1);
    }
}
