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

            public Node(T data, Node next)
            {
                this.Data = data;
                this.Next = next;
            }

            public Node(T data) : this(data, null)
            {

            }

            public override string ToString()
            {
                return Data.ToString();
            }
        }

        private Node _head;
        private Node _tail;

        public LinkedList()
        {
            _head = null;
            _tail = null;
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

        /// <summary>
        /// Insert a new data after the given node element
        /// </summary>
        /// <param name="node">element in list</param>
        /// <param name="newData">data to be added</param>
        private void InsertAfter(Node node, T newData)
        {
            if (node == null)
            {
                throw new Exception("NullNodeElement - node element doesn't exist.");
            }
            Node newNode = new Node(newData, node.Next);
            node.Next = newNode;
        }
    }
}
