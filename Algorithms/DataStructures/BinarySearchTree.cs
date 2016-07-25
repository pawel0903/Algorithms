using System;

namespace Algorithms.DataStructures
{
    public class BinarySearchTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// bst root node
        /// </summary>
        private BinaryTreeNode<T> _root;

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
            if (_root == null)
                _root = new BinaryTreeNode<T>(item);
            else
            {
                BinaryTreeNode<T> current = _root;
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
            InOrder(ref result, _root);
            result += " }";
            return result;
        }
    }
}
