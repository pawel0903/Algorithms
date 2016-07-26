using System;
using Algorithms.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.DataStructures
{
    [TestClass]
    public class BinaryTree
    {
        [TestMethod]
        public void BinaryTreeBasicTest()
        {
            BinaryTree<int> binaryTree = new BinaryTree<int>();
            binaryTree.Insert(8, 0, NodeChildType.Root);
            Assert.AreEqual(true, binaryTree.Insert(3, 8, NodeChildType.Left));
            Assert.AreEqual(false, binaryTree.Insert(3, 8, NodeChildType.Left));
            binaryTree.Insert(1, 3, NodeChildType.Left);
            binaryTree.Insert(6, 3, NodeChildType.Right);
            binaryTree.Insert(4, 6, NodeChildType.Left);
            binaryTree.Insert(7, 6, NodeChildType.Right);
            binaryTree.Insert(10, 8, NodeChildType.Right);
            binaryTree.Insert(14, 10, NodeChildType.Right);
            binaryTree.Insert(13, 14, NodeChildType.Left);
            // https://upload.wikimedia.org/wikipedia/commons/d/da/Binary_search_tree.svg
            Assert.AreEqual("{ 1 3 4 6 7 8 10 13 14 }", binaryTree.ToString());
        }
    }
}
