using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;

namespace Tests.DataStructures
{
    [TestClass]
    public class DirectedGraph
    {
        [TestMethod]
        public void DirectedGraphBasicTest()
        {
            IGraph<int> graph = new DirectedGraph<int>();
            Assert.AreEqual("", graph.ToString());

            graph.AddEdge(0, 1);
            string t1 = String.Format("{0} -> {1}{2}{1}{2}", 0, 1, Environment.NewLine);
            Assert.AreEqual(t1, graph.ToString());
            
            graph.AddEdge(2, 0);
            string t2 = String.Format("{0} -> {1}{3}{1}{3}{2} -> {0}{3}", 0, 1, 2, Environment.NewLine);
            Assert.AreEqual(t2, graph.ToString());
            string t3 = String.Format("{0} -> {1} -> {2}{3}{1}{3}{2} -> {0}{3}", 0, 1, 2, Environment.NewLine);
            graph.AddEdge(0, 2);
            Assert.AreEqual(t3, graph.ToString());
            
            graph.AddVertex(3);
            string t4 = String.Format("{0}{1}{2}", t3, 3, Environment.NewLine);
            Assert.AreEqual(t4, graph.ToString());
            
            Assert.AreEqual(4, graph.CountVertices);
            Assert.AreEqual(3, graph.CountEdges);
        }

        [TestMethod]
        public void DirectedGraphDeleteVertexTest()
        {
            IGraph<int> graph = new DirectedGraph<int>();
            graph.AddEdge(0, 1);
            graph.AddEdge(2, 0);
            graph.AddVertex(3);

            graph.DeleteVertex(3);
            graph.DeleteVertex(2);

            string t1 = String.Format("{0} -> {1}{2}{1}{2}", 0, 1, Environment.NewLine);
            Assert.AreEqual(t1, graph.ToString());

            graph.DeleteVertex(0);
            graph.DeleteVertex(0);

            string t2 = String.Format("{0}{1}", 1, Environment.NewLine);
            Assert.AreEqual(graph.ToString(), t2);

            graph.DeleteVertex(1);
            Assert.AreEqual(graph.ToString(), "");
            Assert.AreEqual(graph.CountVertices, 0);
            Assert.AreEqual(graph.CountEdges, 0);
        }

        [TestMethod]
        public void DirectedGraphDeleteEdgeTest()
        {
            IGraph<int> graph = new DirectedGraph<int>();
            graph.AddEdge(0, 1);
            graph.AddEdge(2, 0);
            graph.AddEdge(3, 2);

            graph.DeleteEdge(0, 1);
            graph.DeleteEdge(0, 2);

            Assert.AreEqual(graph.CountEdges, 2);

            graph.DeleteEdge(2, 0);
            graph.DeleteEdge(3, 2);

            string t = "";
            for (int i = 0; i < 4; i++)
                t += String.Format("{0}{1}", i, Environment.NewLine);

            Assert.AreEqual(t, graph.ToString());
            Assert.AreEqual(0, graph.CountEdges);
            Assert.AreEqual(4, graph.CountVertices);
        }

        [TestMethod]
        public void DirectedGraphGetNeighboursTest()
        {
            IGraph<int> graph = new DirectedGraph<int>();
            graph.AddEdge(0, 1);
            graph.AddEdge(2, 0);
            graph.AddEdge(3, 2);

            Assert.AreEqual(1, graph.GetNeighbours(0)[0]);

            graph.AddEdge(0, 3);
            Assert.AreEqual(2, graph.GetNeighbours(0).Count);

            Assert.AreEqual(null, graph.GetNeighbours(5));
        }
    }
}
