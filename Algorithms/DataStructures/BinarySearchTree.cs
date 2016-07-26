using System;

namespace Algorithms.DataStructures
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        public int Height => GetHeight(Root);
        internal BinaryTreeNode<T> Root { get; private set; }

        public BinarySearchTree()
        {
        }

        /// <summary>
        /// Inserts data into binary search tree
        /// if data already exists does nothing
        /// </summary>
        /// <param name="item">item to be inserted</param>
        /// <returns>true if successfuly inserted, false if data already existed in tree</returns>
        public bool Insert(T item)
        {
            if (Root == null)
                Root = new BinaryTreeNode<T>(item);
            else
            {
                BinaryTreeNode<T> current = Root;
                while (true)
                {
                    if (current.Data.CompareTo(item) == 0)
                        return false; 

                    if (current.Data.CompareTo(item) < 0)
                    {
                        if (current.Right != null)
                            current = current.Right;
                        else
                        {
                            current.Right = new BinaryTreeNode<T>(item);
                            break;
                        }
                    }

                    if (current.Data.CompareTo(item) > 0)
                    {
                        if (current.Left != null)
                            current = current.Left;
                        else
                        {
                            current.Left = new BinaryTreeNode<T>(item);
                            break;
                        }
                    }
                }
            }
            return true;
        }

        private int GetHeight(BinaryTreeNode<T> current)
        {
            if (current == null)
                return 0;

            return Math.Max(GetHeight(current.Left) + 1, GetHeight(current.Right) + 1);
        }

        /// <summary>
        /// traverse tree using inorder treaversal
        /// </summary>
        /// <param name="result">output string</param>
        /// <param name="current">current node</param>
        private void InOrder(ref string result, BinaryTreeNode<T> current)
        {
            if (current != null)
            {
                InOrder(ref result, current.Left);
                result += $" {current.Data}";
                InOrder(ref result, current.Right);
            }
        }

        /// <summary>
        /// prints binary search tree in inorder traversal
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = "{";
            InOrder(ref result, Root);
            result += " }";
            return result;
        }
    }
}
