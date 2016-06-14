using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;

namespace Tests.DataStructures
{
    [TestClass]
    public class LinkedList
    {
        [TestMethod]
        public void LinkedListBasicTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            Assert.AreEqual("{ }", list.ToString());
        }

        [TestMethod]
        public void LinkedListPushTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Push(5);
            Assert.AreEqual("{ 5 }", list.ToString());
            list.Push(10);
            Assert.AreEqual("{ 10 5 }", list.ToString());
            list.Push(1);
            list.Push(20);
            list.Push(30);
            Assert.AreEqual("{ 30 20 1 10 5 }", list.ToString());
            Assert.AreEqual(list.Count, 5);
        }

        [TestMethod]
        public void LinkedListPushBackTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.PushBack(5);
            Assert.AreEqual("{ 5 }", list.ToString());
            list.PushBack(10);
            Assert.AreEqual("{ 5 10 }", list.ToString());
            list.PushBack(1);
            list.PushBack(20);
            list.PushBack(30);
            Assert.AreEqual("{ 5 10 1 20 30 }", list.ToString());
            Assert.AreEqual(list.Count, 5);
        }

        [TestMethod]
        public void LinkedListDeleteTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.PushBack(5);
            list.PushBack(10);
            list.Delete(10);
            Assert.AreEqual("{ 5 }", list.ToString());
            list.Delete(5);
            Assert.AreEqual("{ }", list.ToString());
            list.Delete(5);
            Assert.AreEqual("{ }", list.ToString());
            list.PushBack(5);
            list.PushBack(10);
            list.PushBack(5);
            list.PushBack(11);
            list.Delete(11);
            list.PushBack(1);
            Assert.AreEqual("{ 5 10 5 1 }", list.ToString());
            Assert.AreEqual(list.Count, 4);
        }

        [TestMethod]
        public void LinkedListReverseTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.PushBack(5);
            list.PushBack(10);
            list.PushBack(15);
            list.Reverse();
            Assert.AreEqual("{ 15 10 5 }", list.ToString());
        }

        [TestMethod, Timeout(500)]
        public void LinkedListRotateTest()
        {
            LinkedList<int> list = new LinkedList<int>();
            list.Rotate(1);
            list.PushBack(1);
            list.Rotate(1);
            Assert.AreEqual("{ 1 }", list.ToString());
            list.PushBack(2);
            list.Rotate(3);
            Assert.AreEqual("{ 2 1 }", list.ToString());
            list.Rotate(1);
            Assert.AreEqual("{ 1 2 }", list.ToString());
            list.PushBack(3);
            list.PushBack(4);
            list.PushBack(5);
            list.PushBack(6);
            list.Rotate(4);
            Assert.AreEqual("{ 5 6 1 2 3 4 }", list.ToString());
            list.Rotate(2000000004);
            Assert.AreEqual("{ 5 6 1 2 3 4 }", list.ToString());
        }
    }
}
