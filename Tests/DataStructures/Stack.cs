using System;
using Algorithms.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.DataStructures
{
    [TestClass]
    public class Stack
    {
        [TestMethod]
        public void StackBasicTest()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.AreEqual(stack.Peek(), 3);
            Assert.AreEqual(stack.Pop(), 3);
            Assert.AreEqual(stack.Pop(), 2);
            Assert.AreEqual(stack.Pop(), 1);
            Assert.AreEqual(stack.IsEmpty(), true);
            try
            {
                stack.Peek();
                Assert.Fail();
            }
            catch (Exception)
            {
            }
            stack.Push(11);
            Assert.AreEqual(stack.IsEmpty(), false);
            Assert.AreEqual(stack.Pop(), 11);
        }
    }
}
