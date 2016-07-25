using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DataStructures
{
    internal class BinaryTreeNode<T>
    {
        public T Data { get; set; }
        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }

        public BinaryTreeNode(T data, BinaryTreeNode<T> left = null, BinaryTreeNode<T> right = null)
        {
            Data = data;
            Left = left;
            Right = right;
        }
    }
}
