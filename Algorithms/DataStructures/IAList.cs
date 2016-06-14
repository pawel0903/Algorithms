using System;

namespace Algorithms.DataStructures
{
    public interface IAList<in T> where T : IComparable<T>
    {
        int Count { get; }

        void Delete(T key);
        void Push(T data);
        void PushBack(T data);
        void Reverse();
        void Rotate(int k);
    }
}