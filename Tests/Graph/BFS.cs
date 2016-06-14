using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using static Algorithms.Graphs.GraphAlgorithms;

namespace Tests.Graph
{
    [TestClass]
    public class BFS
    {
        [TestMethod]
        public void BreadthFirstSearchBasicTest()
        {
            IGraph<int> graph = new UndirectGraph<int>();
            graph.AddEdge(1, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 5);
            graph.AddEdge(2, 6);
            graph.AddEdge(4, 7);
            graph.AddEdge(4, 8);
            graph.AddEdge(5, 9);
            graph.AddEdge(5, 10);
            graph.AddEdge(7, 11);
            graph.AddEdge(7, 12);

            List<int> traverseOrder = BreadthFirstSearch(graph, 1);
            for (int i = 0; i < traverseOrder.Count; i++)
            {
                Assert.AreEqual(i+1, traverseOrder[i]);
            }
        }
    }
}
