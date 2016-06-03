using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;

namespace Tests.DataStructures
{
    [TestClass]
    public class DoubleLinkedList
    {
        [TestMethod]
        public void DoubleLinkedListBasicTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            Assert.AreEqual("{ }", list.ToString());
        }

        [TestMethod]
        public void DoubleLinkedListPushTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
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
        public void DoubleLinkedListPushBackTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
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
        public void DoubleLinkedListDeleteTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
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
        public void DoubleLinkedListReverseTest1()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.PushBack(5);
            list.PushBack(10);
            list.PushBack(15);
            list.Reverse();
            list.PushBack(20);
            Assert.AreEqual("{ 15 10 5 20 }", list.ToString());
            list.PushBack(1);
            Assert.AreEqual("{ 15 10 5 20 1 }", list.ToString());
            list.Push(1);
            list.Reverse();
            Assert.AreEqual("{ 1 20 5 10 15 1 }", list.ToString());
        }

        [TestMethod]
        public void DoubleLinkedListReverseTest2()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
            list.Delete(1);
            list.Push(5);
            list.Push(10);
            list.Push(15);
            list.Reverse();
            list.PushBack(20);
            Assert.AreEqual("{ 5 10 15 20 }", list.ToString());
            list.PushBack(1);
            Assert.AreEqual("{ 5 10 15 20 1 }", list.ToString());
            list.Push(1);
            list.Reverse();
            Assert.AreEqual("{ 1 20 15 10 5 1 }", list.ToString());
            list.Delete(20);
            Assert.AreEqual("{ 1 15 10 5 1 }", list.ToString());
            list.Delete(20);
            Assert.AreEqual("{ 1 15 10 5 1 }", list.ToString());
            list.Delete(1);
            list.Delete(5);
            Assert.AreEqual("{ 15 10 1 }", list.ToString());
            list.Rotate(1);
            Assert.AreEqual("{ 10 1 15 }", list.ToString());
            list.Reverse();
            Assert.AreEqual("{ 15 1 10 }", list.ToString());
            list.Rotate(1);
            Assert.AreEqual("{ 1 10 15 }", list.ToString());
            list.Push(0);
            list.PushBack(20);
            Assert.AreEqual("{ 0 1 10 15 20 }", list.ToString());
            list.Rotate(2);
            Assert.AreEqual("{ 10 15 20 0 1 }", list.ToString());
            list.Reverse();
            Assert.AreEqual("{ 1 0 20 15 10 }", list.ToString());
        }

        [TestMethod, Timeout(500)]
        public void DoubleLinkedListRotateTest()
        {
            DoubleLinkedList<int> list = new DoubleLinkedList<int>();
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
