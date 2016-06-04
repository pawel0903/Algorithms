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

        public bool IsEmpty()
        {
            return _stack.Count > 0 ? false : true;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Stack is empty!");
            }

            return _stack[_stack.Count - 1];
        }

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

        public void Push(T item)
        {
            _stack.Add(item);
        }
    }
}
