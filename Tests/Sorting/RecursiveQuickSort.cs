﻿using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Sorting;
using static Tests.Sorting.Common.Tests;

namespace Tests.Sorting
{
    [TestClass]
    public class RecursiveQuickSort
    {
        [TestMethod]
        public void RecursiveQuickSortBasicTest() => BasicSortingTest(Algorithms.Sorting.Sorting.RecursiveQuickSort);
    }
}
