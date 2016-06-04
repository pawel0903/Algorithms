using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// Generic Stack implementation
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class Stack<T> where T : IComparable<T>
    {
        private List<T> _stack;

        public Stack()
        {
            _stack = new List<T>();
        }

        /// <summary>
        /// Checks if stack is empty
        /// </summary>
        /// <returns>true if stack is empty, false otherwise</returns>
        public bool IsEmpty()
        {
            return _stack.Count > 0 ? false : true;
        }

        /// <summary>
        /// Peeks as last element, throws error if stack is empty
        /// </summary>
        /// <returns>last element</returns>
        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack is empty!");
            }

            return _stack[_stack.Count - 1];
        }

        /// <summary>
        /// Returns the last element and deletes it from stack,
        /// throws error if stack is empty
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack is empty!");
            }

            T result = _stack[_stack.Count - 1];
            _stack.RemoveAt(_stack.Count - 1);
            return result;
        }

        /// <summary>
        /// Adds element to stack
        /// </summary>
        /// <param name="item">element</param>
        public void Push(T item)
        {
            _stack.Add(item);
        }
    }
}
