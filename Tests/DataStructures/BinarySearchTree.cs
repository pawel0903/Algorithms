using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;

namespace Tests.DataStructures
{
    [TestClass]
    public class BinarySearchTree
    {
        [TestMethod]
        public void BinarySearchTreeBasicTest()
        {
            BinarySearchTree<int> bst = new BinarySearchTree<int>();
            bst.Insert(8);
            Assert.AreEqual("{ 8 }", bst.ToString());
            Assert.AreEqual(true, bst.Insert(3));
            Assert.AreEqual(false, bst.Insert(3));
            Assert.AreEqual("{ 3 8 }", bst.ToString());
            bst.Insert(10);
            bst.Insert(1);
            bst.Insert(6);
            bst.Insert(14);
            bst.Insert(4);
            bst.Insert(7);
            bst.Insert(13);
            // https://upload.wikimedia.org/wikipedia/commons/d/da/Binary_search_tree.svg
            // inorder: { 1 3 4 6 7 8 10 13 14 }
            Assert.AreEqual("{ 1 3 4 6 7 8 10 13 14 }", bst.ToString());
        }
    }
}
