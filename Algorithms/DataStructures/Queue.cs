using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// Generic Queue implementation using linked list
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class Queue<T>
    {
        private readonly List<T> _queue;

        public Queue()
        {
            _queue = new List<T>();
        }

        /// <summary>
        /// Checks if the queue is empty
        /// Time complexity O(1)
        /// </summary>
        /// <returns>true if queue is empty, false otherwise</returns>
        public bool IsEmpty()
        {
            return _queue.Count == 0;
        }

        /// <summary>
        /// Adds an item to the queue.
        /// Time complexity O(1)
        /// </summary>
        /// <param name="item">item to be added</param>
        public void Enqueue(T item)
        {
            _queue.Add(item);
        }

        /// <summary>
        /// Removes an item from the queue. The items are popped in the same order in which they are pushed.
        /// Time complexity O(1)
        /// </summary>
        /// <returns>removed item</returns>
        public T Dequeue()
        {
            if (_queue.Count == 0)
                throw new Exception("Queue is empty. Cannot Dequeue.");
            T item = _queue.First();
            _queue.Remove(item);
            return item;
        }

        /// <summary>
        /// Return the first element in queue.
        /// Does not remove the element.
        /// Throws exception if queue is empty
        /// Time complexity O(1)
        /// </summary>
        /// <returns>First element in queue</returns>
        public T Front()
        {
            if(IsEmpty())
                throw new Exception("Queue is empty. Cannot peek the front element.");
            return _queue.First();
        }

        /// <summary>
        /// Return last element in queue.
        /// Does not remove the element.
        /// Throws exception if queue is empty
        /// Time complexity O(1)
        /// </summary>
        /// <returns>Lase element in queue</returns>
        public T Rear()
        {
            if (IsEmpty())
                throw new Exception("Queue is empty. Cannot peek the last element.");
            return _queue.Last();
        }
    }
}
