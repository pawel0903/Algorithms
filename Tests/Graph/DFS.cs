using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using static Algorithms.Graphs.GraphAlgorithms;

namespace Tests.Graph
{
    [TestClass]
    public class DFS
    {
        [TestMethod]
        public void DepthFirstSearchBasicTest()
        {
            IGraph<int> graph = new UndirectGraph<int>();
            graph.AddEdge(1, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);
            graph.AddEdge(3, 5);
            graph.AddEdge(2, 6);
            graph.AddEdge(1, 7);
            graph.AddEdge(1, 8);
            graph.AddEdge(8, 9);
            graph.AddEdge(9, 10);
            graph.AddEdge(9, 11);
            graph.AddEdge(8, 12);

            List<int> traverseOrder = DepthFirstSearch(graph, 1);
            for (int i = 0; i < traverseOrder.Count; i++)
            {
                Assert.AreEqual(i+1, traverseOrder[i]);
            }
        }
    }
}
