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
            Assert.AreEqual("", graph.ToString());

            graph.AddEdge(0, 1);
            string t1 = String.Format("{0} -> {1}{2}{1} -> {0}{2}", 0, 1, Environment.NewLine);
            Assert.AreEqual(t1, graph.ToString());

            graph.AddEdge(2, 0);
            string t2 = String.Format("{0} -> {1} -> {2}{3}{1} -> {0}{3}{2} -> {0}{3}", 0, 1, 2, Environment.NewLine);
            Assert.AreEqual(t2, graph.ToString());
            graph.AddEdge(0, 2);
            Assert.AreEqual(t2, graph.ToString());

            graph.AddVertex(3);
            string t3 = String.Format("{0}{1}{2}", t2, 3, Environment.NewLine);
            Assert.AreEqual(t3, graph.ToString());

            Assert.AreEqual(4, graph.CountVertices);
            Assert.AreEqual(2, graph.CountEdges);
        }

        [TestMethod]
        public void UndirectGraphDeleteVertexTest()
        {
            UndirectGraph<int> graph = new UndirectGraph<int>();
            graph.AddEdge(0, 1);
            graph.AddEdge(2, 0);
            graph.AddVertex(3);

            graph.DeleteVertex(3);
            graph.DeleteVertex(2);

            string t1 = String.Format("{0} -> {1}{2}{1} -> {0}{2}", 0, 1, Environment.NewLine);
            Assert.AreEqual(t1, graph.ToString());

            graph.DeleteVertex(0);
            graph.DeleteVertex(0);

            string t2 = String.Format("{0}{1}", 1, Environment.NewLine);
            Assert.AreEqual(t2, graph.ToString());

            graph.DeleteVertex(1);
            Assert.AreEqual("", graph.ToString());
            Assert.AreEqual(0, graph.CountVertices);
            Assert.AreEqual(0, graph.CountEdges);
        }

        [TestMethod]
        public void UndirectGraphDeleteEdgeTest()
        {
            UndirectGraph<int> graph = new UndirectGraph<int>();
            graph.AddEdge(0, 1);
            graph.AddEdge(2, 0);
            graph.AddEdge(3, 2);

            graph.DeleteEdge(0, 1);
            graph.DeleteEdge(0, 2);

            Assert.AreEqual(1, graph.CountEdges);

            graph.DeleteEdge(2, 3);

            string t = "";
            for (int i = 0; i < 4; i++)
                t += String.Format("{0}{1}", i, Environment.NewLine);

            Assert.AreEqual(t, graph.ToString());
            Assert.AreEqual(0, graph.CountEdges);
            Assert.AreEqual(4, graph.CountVertices);
        }

        [TestMethod]
        public void UndirectGraphGetNeighboursTest()
        {
            IGraph<int> graph = new UndirectGraph<int>();
            graph.AddEdge(0, 1);
            graph.AddEdge(2, 0);
            graph.AddEdge(3, 2);

            Assert.AreEqual(1, graph.GetNeighbours(0)[0]);
            Assert.AreEqual(2, graph.GetNeighbours(0)[1]);

            Assert.AreEqual(2, graph.GetNeighbours(0).Count);

            graph.AddEdge(0, 3);
            Assert.AreEqual(3, graph.GetNeighbours(0).Count);

            Assert.AreEqual(null, graph.GetNeighbours(5));
        }
    }
}
