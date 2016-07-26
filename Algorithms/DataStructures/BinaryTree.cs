using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        internal BinaryTreeNode<T> Root { get; private set; }

        public BinaryTree()
        {
        }

        public bool Insert(T item, T parent, NodeChildType childType)
        {
            if (childType == NodeChildType.Root)
            {
                if (Root != null)
                    return false;

                Root = new BinaryTreeNode<T>(item);
            }
            else
            {
                BinaryTreeNode<T> p = Find(parent);

                if (p != null)
                {
                    switch (childType)
                    {
                        case NodeChildType.Left:
                            p.Left = new BinaryTreeNode<T>(item);
                            break;
                        case NodeChildType.Right:
                            p.Right = new BinaryTreeNode<T>(item);
                            break;
                    }
                }
                else
                    return false;
            }

            return true;
        }

        private BinaryTreeNode<T> Find(T item)
        {
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            stack.Push(Root);

            while (!stack.IsEmpty())
            {
                BinaryTreeNode<T> current = stack.Pop();
                if (current != null)
                {
                    if(current.Data.CompareTo(item) == 0)
                        return current;

                    if (current.Left != null)
                        stack.Push(current.Left);

                    if (current.Right != null)
                        stack.Push(current.Right);
                }
            }

            return null;
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
