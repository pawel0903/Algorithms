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
        /// Traverse graph in depth first order
        /// Returns traverse path as List
        /// Time Complexity: O(V+E)
        /// where V is number of vertices in the graph and E is number of edges in the graph
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="graph">Graph to be traversed</param>
        /// <param name="first">start point in graph</param>
        /// <returns>Traverse path</returns>
        public static List<T> DepthFirstSearch<T>(IGraph<T> graph, T first)
        {
            List<T> result = new List<T>();
            DataStructures.Stack<T> stack = new DataStructures.Stack<T>();
            HashSet<T> visited = new HashSet<T>();

            stack.Push(first);

            while (!stack.IsEmpty())
            {
                T current = stack.Pop();
                visited.Add(current);
                result.Add(current);

                foreach (var neighbour in graph.GetNeighbours(current))
                {
                    if (!visited.Contains(current))
                        stack.Push(neighbour);
                }
            }

            return result;
        }
    }
}
