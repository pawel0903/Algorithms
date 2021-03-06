﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// Directed Graph implementation using adjacent list
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class DirectedGraph<T> : IGraph<T>
    {
        private readonly Dictionary<T, List<T>> _graph;

        /// <summary>
        /// Counts number of edges in direct graph
        /// </summary>
        public int CountEdges => (from e in _graph.Values select e.Count).Sum();
        /// <summary>
        /// Counts number of vertices in undirect graph
        /// </summary>
        public int CountVertices => _graph.Keys.Count;

        public DirectedGraph()
        {
            _graph = new Dictionary<T, List<T>>();
        }

        /// <summary>
        /// Adds an edge to a graph
        /// </summary>
        /// <param name="src">first vertex</param>
        /// <param name="dest">second vertex</param>
        public void AddEdge(T src, T dest)
        {
            Add(src, dest);
            CheckExistAndAdd(dest);
        }

        /// <summary>
        /// Adds vertex to a graph
        /// If exists does nothing
        /// </summary>
        /// <param name="vertex">vertex to be added to graph</param>
        public void AddVertex(T vertex) => CheckExistAndAdd(vertex);

        /// <summary>
        /// Deletes vertex from graph
        /// If doesnt exist does nothing
        /// </summary>
        /// <param name="src">first vertex</param>
        /// <param name="dest">second vertex</param>
        public void DeleteEdge(T src, T dest)
        {
            if (_graph.ContainsKey(src) && _graph.ContainsKey(dest))
            {
                _graph[src].Remove(dest);
            }
        }

        /// <summary>
        /// Deletes vertex from graph
        /// If vertex doesnt exist does nothing
        /// </summary>
        /// <param name="vertex">vertex to be deleted</param>
        public void DeleteVertex(T vertex)
        {
            if (_graph.ContainsKey(vertex))
            {
                foreach (var neighbour in _graph[vertex].ToList())
                {
                    _graph[neighbour].Remove(vertex);
                }

                _graph.Remove(vertex);
            }
        }

        /// <summary>
        /// Return vertex neighbours as list
        /// If vertex doesn't exist return null
        /// </summary>
        /// <param name="vertex">vertex</param>
        /// <returns>Neighbours of given vertex</returns>
        public List<T> GetNeighbours(T vertex) => _graph.ContainsKey(vertex) ? _graph[vertex] : null;

        /// <summary>
        /// Returns graph vertices as list
        /// </summary>
        /// <returns>vertices</returns>
        public List<T> GetVertices() => _graph.Keys.ToList();

        /// <summary>
        /// Adds an edge to a graph
        /// If vertices don't exists cretes them
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
