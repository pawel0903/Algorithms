using System;
using Algorithms.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Trees;

namespace Tests.Trees
{
    [TestClass]
    public class MorisTreeTraversal
    {
        [TestMethod]
        public void MorisInorderTraversal()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.Insert(8);
            bst.Insert(3);
            bst.Insert(10);
            bst.Insert(1);
            bst.Insert(6);
            bst.Insert(14);
            bst.Insert(4);
            bst.Insert(7);
            bst.Insert(13);
            Assert.AreEqual(bst.ToString(), bst.MorrisInOrder());
        }
    }
}
