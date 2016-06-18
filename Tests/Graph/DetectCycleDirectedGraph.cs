using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Algorithms.DataStructures;
using static Algorithms.Graphs.GraphAlgorithms;

namespace Tests.Graph
{
    [TestClass]
    public class DetectCycleDirectedGraph
    {
        [TestMethod]
        public void DetectCycleDirectedGraphBasicTest()
        {
            var graph = new DirectedGraph<int>();
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);

            Assert.AreEqual(false, IsCyclic(graph));

            graph.AddEdge(3, 3);

            Assert.AreEqual(true, IsCyclic(graph));

            graph.DeleteEdge(3, 3);
            graph.AddEdge(4, 2);

            Assert.AreEqual(true, IsCyclic(graph));

            graph.DeleteEdge(4, 2);
            graph.AddEdge(8, 8);

            Assert.AreEqual(true, IsCyclic(graph));
        }
    }
}
