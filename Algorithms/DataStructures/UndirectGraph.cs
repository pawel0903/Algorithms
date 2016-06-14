using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.DataStructures;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// Undirect Graph implementation using adjacent list
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class UndirectGraph<T> : IGraph<T>
    {
        private readonly DirectedGraph<T> _graph;

        /// <summary>
        /// Counts number of edges in undirect graph
        /// </summary>
        public int CountEdges => _graph.CountEdges / 2;

        /// <summary>
        /// Counts number of vertices in undirect graph
        /// </summary>
        public int CountVertices => _graph.CountVertices;

        public UndirectGraph()
        {
            _graph = new DirectedGraph<T>();
        }

        /// <summary>
        /// Adds an edge to a graph
        /// </summary>
        /// <param name="src">first vertex</param>
        /// <param name="dest">second vertex</param>
        public void AddEdge(T src, T dest)
        {
            _graph.AddEdge(src, dest);
            _graph.AddEdge(dest, src);
        }

        /// <summary>
        /// Adds vertex to a graph
        /// If exists does nothing
        /// </summary>
        /// <param name="vertex">vertex to be added to graph</param>
        public void AddVertex(T vertex)
        {
            _graph.AddVertex(vertex);
        }

        /// <summary>
        /// Deletes vertex from graph
        /// If doesnt exist does nothing
        /// </summary>
        /// <param name="src">first vertex</param>
        /// <param name="dest">second vertex</param>
        public void DeleteEdge(T src, T dest)
        {
            _graph.DeleteEdge(src, dest);
            _graph.DeleteEdge(dest, src);
        }

        /// <summary>
        /// Deletes vertex from graph
        /// If vertex doesnt exist does nothing
        /// </summary>
        /// <param name="vertex">vertex to be deleted</param>
        public void DeleteVertex(T vertex)
        {
            _graph.DeleteVertex(vertex);
        }

        /// <summary>
        /// Return vertex neighbours as list
        /// If vertex doesn't exist return null
        /// </summary>
        /// <param name="vertex">vertex</param>
        /// <returns>Neighbours of given vertex</returns>
        public List<T> GetNeighbours(T vertex) => _graph.GetNeighbours(vertex);

        public override string ToString()
        {
            return _graph.ToString();
        }
    }
}
