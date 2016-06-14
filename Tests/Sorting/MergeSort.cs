using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tests.Sorting.Common.Tests;

namespace Tests.Sorting
{
    [TestClass]
    public class MergeSort
    {
        [TestMethod]
        public void MergeSortBasicTest() => BasicSortingTest(Algorithms.Sorting.Sorting.MergeSort);
    }
}
