using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// Undirect Graph implementation using adjacent list
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class UndirectGraph<T>
    {
        private readonly Dictionary<T, List<T>> _graph;

        public UndirectGraph()
        {
            _graph = new Dictionary<T, List<T>>();
        }

        /// <summary>
        /// Adds an edge to a graph
        /// </summary>
        /// <param name="src">source</param>
        /// <param name="dest">destination</param>
        public void AddEdge(T src, T dest)
        {
            Add(src, dest);
            Add(dest, src);
        }

        /// <summary>
        /// Adds vertex to a graph
        /// If exists does nothing
        /// </summary>
        /// <param name="vertex">vertex to be added to graph</param>
        public void AddVertex(T vertex)
        {
            CheckExistAndAdd(vertex);
        }

        /// <summary>
        /// Adds an edge to a graph
        /// </summary>
        /// <param name="src">source</param>
        /// <param name="dest">destination</param>
        private void Add(T src, T dest)
        {
            CheckExistAndAdd(src);

            foreach (var neighbour in _graph[src])
            {
                if (neighbour.Equals(dest))
                    return;
            }

            _graph[src].Add(dest);
        }

        /// <summary>
        /// Checks if vertex exist in graph
        /// If yes does nothing, otherwise adds a key to a graph
        /// </summary>
        /// <param name="key"></param>
        private void CheckExistAndAdd(T key)
        {
            if (!_graph.ContainsKey(key))
                _graph.Add(key, new List<T>());
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var vertex in _graph.Keys)
            {
                result.Append(vertex);
                foreach (var neighbour in _graph[vertex])
                {
                    result.Append(" -> ").Append(neighbour);
                }
                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }
    }
}
