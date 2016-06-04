using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Sorting;
using static Tests.Sorting.Common.Tests;

namespace Tests.Sorting
{
    [TestClass]
    public class InsertionSort
    {
        [TestMethod]
        public void InsertionSortBasicTest() => BasicSortingTest(Algorithms.Sorting.Sorting.InsertionSort);
    }
}
