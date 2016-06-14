using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tests.Sorting.Common.Tests;

namespace Tests.Sorting
{
    [TestClass]
    public class BubbleSort
    {
        [TestMethod]
        public void BubbleSortBasicTest() => BasicSortingTest(Algorithms.Sorting.Sorting.BubbleSort);
    }
}
