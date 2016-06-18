using System.Collections.Generic;
using Algorithms.DataStructures;

namespace Algorithms.Graphs
{
    public static partial class GraphAlgorithms
    {
        /// <summary>
        /// Check if joint graph contains cycle
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="graph">graph</param>
        /// <param name="vertex">current vertex</param>
        /// <param name="visited">visited vertices</param>
        /// <param name="recStack">used for checking for back egdes</param>
        /// <returns>true if graph contains cycle, false otherwise</returns>
        private static bool IsCyclicUtil<T>(DirectedGraph<T> graph, T vertex, ref HashSet<T> visited, ref HashSet<T> recStack)
        {
            if (!visited.Contains(vertex))
            {
                visited.Add(vertex);
                recStack.Add(vertex);

                foreach (var neighbour in graph.GetNeighbours(vertex))
                {
                    if (!visited.Contains(neighbour) && IsCyclicUtil(graph, neighbour, ref visited, ref recStack))
                        return true;

                    if (recStack.Contains(neighbour))
                        return true;
                }
            }

            recStack.Remove(vertex);

            return false;
        }

        /// <summary>
        /// Checks if directed graph contains cycle
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="graph">graph</param>
        /// <returns>true if graph contains cycle, false otherwise</returns>
        public static bool IsCyclic<T>(DirectedGraph<T> graph)
        {
            HashSet<T> visited = new HashSet<T>();
            HashSet<T> recStack = new HashSet<T>();

            foreach (var vertex in graph.GetVertices())
            {
                if (IsCyclicUtil(graph, vertex, ref visited, ref recStack))
                    return true;
            }

            return false;
        }
    }
}
