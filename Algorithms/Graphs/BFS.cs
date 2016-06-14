using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.DataStructures;

namespace Algorithms.Graphs
{
    public static partial class GraphAlgorithms
    {
        /// <summary>
        /// Traverse graph in breadth first order
        /// Returns traverse path as List
        /// Time Complexity: O(V+E)
        /// where V is number of vertices in the graph and E is number of edges in the graph
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="graph">Graph to be traversed</param>
        /// <param name="first">start point in graph</param>
        /// <returns>Traverse path</returns>
        public static List<T> BreadthFirstSearch<T>(IGraph<T> graph, T first)
        {
            List<T> result = new List<T>();
            DataStructures.Queue<T> queue = new DataStructures.Queue<T>();
            HashSet<T> visited = new HashSet<T>();

            queue.Enqueue(first);

            while (!queue.IsEmpty())
            {
                T current = queue.Dequeue();
                result.Add(current);
                List<T> neighbours = graph.GetNeighbours(current);
                visited.Add(current);

                foreach (var neighbour in neighbours)
                {
                    if (!visited.Contains(neighbour))
                    {
                        queue.Enqueue(neighbour);
                    }
                }
            }

            return result;
        }
    }
}
