using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.DataStructures;

namespace Algorithms.Trees
{
    public static class MorisTreeTraversal
    {
        /// <summary>
        /// Returns inorder predecessor of given node
        /// </summary>
        /// <typeparam name="T">type</typeparam>
        /// <param name="node">node</param>
        /// <returns>predecessor of given node</returns>
        private static BinaryTreeNode<T> FindPredecessor<T>(BinaryTreeNode<T> node)
        {
            if (node == null)
                return null;

            BinaryTreeNode<T> current = node.Left;
            while (current.Right != null && current.Right != node)
            {
                current = current.Right;
            }
                
            return current;
        }

        private static string MorrisInOrder<T>(BinaryTreeNode<T> root) where T : IComparable<T>
        {
            string result = "{";
            BinaryTreeNode<T> current = root;
            while (current != null)
            {
                if (current.Left == null)
                {
                    result += $" {current.Data}";
                    current = current.Right;
                }
                else
                {
                    BinaryTreeNode<T> pred = FindPredecessor<T>(current);
                    if (pred.Right == null)
                    {
                        //result += $" {current.Data}";
                        pred.Right = current;
                        current = current.Left;
                    }
                    else
                    {
                        pred.Right = null;
                        result += $" {current.Data}";
                        current = current.Right;
                    }
                }
            }

            return result + " }";
        }

        public static string MorrisInOrder<T>(this BinarySearchTree<T> tree) where T : IComparable<T>
        {
            return MorrisInOrder(tree.Root);
        }
    }
}
