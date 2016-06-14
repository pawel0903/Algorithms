using System.Collections.Generic;
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
                visited.Add(current);

                foreach (var neighbour in graph.GetNeighbours(current))
                {
                    if (!visited.Contains(neighbour))
                        queue.Enqueue(neighbour);
                }
            }

            return result;
        }
    }
}
