using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;

namespace Tests.DataStructures
{
    [TestClass]
    public class MinHeap
    {
        [TestMethod]
        public void MinHeapBasicTest()
        {
            MinHeap<int> heap = new MinHeap<int>(1);
            heap.InsertKey(2);
            heap.InsertKey(3);
            heap.InsertKey(1);
            Assert.AreEqual(1, heap.GetMin());
            heap.InsertKey(0);
            heap.InsertKey(-1);
            Assert.AreEqual(-1, heap.GetMin());
            // [-1, 0, 2, 3, 1]
            heap.DecreaseKey(2, -100);
            Assert.AreEqual(-100, heap.GetMin());
            Assert.AreEqual(-100, heap.ExtractMin());
            Assert.AreEqual(-1, heap.ExtractMin());
            Assert.AreEqual(0, heap.ExtractMin());
            heap.DeleteKey(0, int.MinValue);
            Assert.AreEqual(3, heap.ExtractMin());
        }
    }
}
