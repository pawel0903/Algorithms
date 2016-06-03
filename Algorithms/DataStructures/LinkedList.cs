using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// Generic LinkList implementation
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class LinkedList<T> where T : IComparable<T>
    {
        /// <summary>
        /// Node class
        /// </summary>
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }

            public Node(T data, Node next = null)
            {
                this.Data = data;
                this.Next = next;
            }

            public override string ToString()
            {
                return Data.ToString();
            }
        }

        /// <summary>
        /// Counts number of items in list
        /// </summary>
        public int Count { get; private set; }

        private Node _head;
        private Node _tail;

        public LinkedList()
        {
            _head = null;
            _tail = null;
            Count = 0;
        }

        /// <summary>
        /// Deletes first occurance of a given key, if a given key doesn't exist does nothing
        /// Time complexity O(n)
        /// </summary>
        /// <param name="key">item to be deleted</param>
        public void Delete(T key)
        {
            Node current = _head;
            Node prev = null;
            while (current != null)
            {
                if (current.Data.CompareTo(key) == 0)
                {
                    // 1 element
                    if (prev == null)
                        _head = _tail = null;
                    // 2 or more
                    else
                    {
                        prev.Next = current.Next;
                        // deleting last element
                        if (current.Next == null)
                            _tail = prev;
                    }
                    Count--;
                    return;
                }
                prev = current;
                current = current.Next;
            }
        }

        /// <summary>
        /// Pushes item at the front of a linked list
        /// Time complexity O(1)
        /// </summary>
        /// <param name="data">item to be added</param>
        public void Push(T data)
        {
            Node node = new Node(data, _head);
            _head = node;
            if (_head.Next == null)
            {
                _tail = _head;
            }
            Count++;
        }

        /// <summary>
        /// Pushes item at the back of a linked list
        /// Time complexity O(1)
        /// </summary>
        /// <param name="data">item to be added</param>
        public void PushBack(T data)
        {
            Node node = new Node(data);
            if (_head == null)
            {
                _head = _tail = node;
            }
            else
            {
                _tail.Next = node;
                _tail = _tail.Next;
            }
            Count++;
        }

        /// <summary>
        /// Reverse a link list
        /// Time complexity O(n)
        /// </summary>
        public void Reverse()
        {
            if (_head == null)
                return;

            _tail = _head;
            Node current = _head;
            Node prev = null;

            while (current != null)
            {
                Node next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            _head = prev;
        }

        /// <summary>
        /// Rotates the linked list counter-clockwise by k nodes
        /// Time complexity O(k)
        /// </summary>
        /// <param name="k">number of nodes</param>
        public void Rotate(int k)
        {
            if (Count <= 1 || k%Count == 0)
                return;

            k %= Count;

            Node current = _head;
            Node prev = null;
            for (int i = 0; i < k; i++)
            {
                if (i == k - 1)
                    prev = current;

                current = current.Next;
            }

            if (prev != null)
                prev.Next = null;

            _tail.Next = _head;
            _head = current;
            
            _tail = prev;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            Node current = _head;
            result.Append("{ ");
            while (current != null)
            {
                result.Append(current.ToString() + " ");
                current = current.Next;
            }
            result.Append("}");
            return result.ToString();
        }
    }
}
