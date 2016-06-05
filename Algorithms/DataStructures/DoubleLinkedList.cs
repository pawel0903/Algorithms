using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Algorithms.Common.Utils;

namespace Algorithms.DataStructures
{
    /// <summary>
    /// Generic DoubleLinkList implementation
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class DoubleLinkedList<T> : IAList<T> where T : IComparable<T>
    {
        /// <summary>
        /// Node class
        /// </summary>
        protected class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }

            public Node(T data, Node next = null, Node prev = null)
            {
                this.Data = data;
                this.Next = next;
                this.Prev = prev;
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
        private bool _reversed;

        public DoubleLinkedList()
        {
            _head = null;
            _tail = null;
            Count = 0;
            _reversed = false;
        }

        /// <summary>
        /// Deletes first occurance of a given key, if a given key doesn't exist does nothing
        /// Time complexity O(n)
        /// </summary>
        /// <param name="key">item to be deleted</param>
        public void Delete(T key)
        {
            Node current = _head;
            while (current != null)
            {
                if (current.Data.CompareTo(key) == 0)
                {
                    Node next = GetNext(current);
                    Node prev = GetPrev(current);

                    if (current == _head && current == _tail)
                    {
                        _head = _tail = null;
                    }   
                    else if (current == _head)
                    {
                        SetPrev(ref next, null);
                        SetNext(ref _head, null);
                        _head = next;
                    }
                    else if (current == _tail)
                    {
                        SetNext(ref prev, null);
                        SetPrev(ref _tail, null);
                        _tail = prev;
                    }
                    // removing from middle
                    else
                    {
                        SetNext(ref prev, next);
                        SetPrev(ref next, prev);
                    }

                    Count--;
                    return;
                }
                current = GetNext(current);
            }
        }

        /// <summary>
        /// Pushes item at the front of double linked list
        /// Time complexity O(1)
        /// </summary>
        /// <param name="data">item to be added</param>
        public void Push(T data)
        {
            Node node = new Node(data);
            if (_head == null)
            {
                _head = _tail = node;
            }
            else
            {
                SetPrev(ref _head, node);
                SetNext(ref node, _head);
                _head = node;
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
                SetPrev(ref node, _tail);
                SetNext(ref _tail, node);
                _tail = GetNext(_tail);
            }
            Count++;
        }

        /// <summary>
        /// Reverse a double link list
        /// Time complexity O(1)
        /// </summary>
        public void Reverse()
        {
            _reversed = !_reversed;
            Swap(ref _head, ref _tail);
        }

        /// <summary>
        /// Rotates the double linked list counter-clockwise by k nodes
        /// Time complexity O(k%n)
        /// </summary>
        /// <param name="k">number of nodes</param>
        public void Rotate(int k)
        {
            if (Count <= 1 || k%Count == 0)
                return;

            k %= Count;

            Node current = _head;
            for (int i = 0; i < k; i++)
            {
                current = GetNext(current);
            }

            Node prev = GetPrev(current);
            
            SetNext(ref prev, null);
            SetPrev(ref current, null);
            SetNext(ref _tail, _head);
            SetPrev(ref _head, _tail);

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
                current = GetNext(current); //current.Next;
            }
            result.Append("}");
            return result.ToString();
        }

        /// <summary>
        /// Helper method - sets next node of current node to data node
        /// Used becouse of reverse function
        /// </summary>
        /// <param name="current">node to be set</param>
        /// <param name="data">value</param>
        private void SetNext(ref Node current, Node data)
        {
            if (_reversed)
                current.Prev = data;
            else
                current.Next = data;
        }

        /// <summary>
        /// Helper method - sets prev node of current node to data node
        /// Used becouse of reverse function
        /// </summary>
        /// <param name="current">node to be set</param>
        /// <param name="data">value</param>
        private void SetPrev(ref Node current, Node data)
        {
            if (_reversed)
                current.Next = data;
            else
                current.Prev = data;
        }

        /// <summary>
        /// Helper method - gets next node
        /// Used becouse of reverse function
        /// </summary>
        /// <param name="node">current node</param>
        /// <returns>Next node</returns>
        private Node GetNext(Node node)
        {
            return _reversed ? node.Prev : node.Next;
        }

        /// <summary>
        /// Helper method - gets previous node
        /// Used becouse of reverse function
        /// </summary>
        /// <param name="node">current node</param>
        /// <returns>Previous node</returns>
        private Node GetPrev(Node node)
        {
            return _reversed ? node.Next : node.Prev;
        }
    }
}
