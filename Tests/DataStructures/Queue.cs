using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;

namespace Tests.DataStructures
{
    [TestClass]
    public class Queue
    {
        [TestMethod]
        public void QueueBasicTest()
        {
            Queue<int> queue = new Queue<int>();
            Assert.AreEqual(queue.IsEmpty(), true);
            for (int i = 1; i <= 5; i++)
            {
                queue.Enqueue(i);
            }
            Assert.AreEqual(queue.Front(), 1);
            Assert.AreEqual(queue.Rear(), 5);
            for (int i = 1; i <= 5; i++)
            {
                Assert.AreEqual(queue.Dequeue(), i);
            }
            Assert.AreEqual(queue.IsEmpty(), true);
            try
            {
                queue.Dequeue();
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Queue is empty. Cannot Dequeue.", ex.Message);
            }
        }
    }
}
