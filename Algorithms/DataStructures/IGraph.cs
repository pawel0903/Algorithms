using System.Collections.Generic;

namespace Algorithms.DataStructures
{
    public interface IGraph<T>
    {
        int CountEdges { get; }
        int CountVertices { get; }

        void AddEdge(T src, T dest);
        void AddVertex(T vertex);
        void DeleteEdge(T src, T dest);
        void DeleteVertex(T vertex);
        List<T> GetNeighbours(T vertex);
    }
}