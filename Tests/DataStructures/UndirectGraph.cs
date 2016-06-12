using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;

namespace Tests.DataStructures
{
    [TestClass]
    public class UndirectGraph
    {
        [TestMethod]
        public void UndirectGraphBasicTest()
        {
            UndirectGraph<int> graph = new UndirectGraph<int>();
            Assert.AreEqual(graph.ToString(), "");

            graph.AddEdge(0, 1);
            string t1 = String.Format("{0} -> {1}{2}{1} -> {0}{2}", 0, 1, Environment.NewLine);
            Assert.AreEqual(graph.ToString(), t1);

            graph.AddEdge(2, 0);
            string t2 = String.Format("{0} -> {1} -> {2}{3}{1} -> {0}{3}{2} -> {0}{3}", 0, 1, 2, Environment.NewLine);
            Assert.AreEqual(graph.ToString(), t2);
            graph.AddEdge(0, 2);
            Assert.AreEqual(graph.ToString(), t2);

            graph.AddVertex(3);
            string t3 = String.Format("{0}{1}{2}", t2, 3, Environment.NewLine);
            Assert.AreEqual(graph.ToString(), t3);
        }
    }
}
