using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.Searching.Structures;

namespace Tests.Searching
{
    [TestClass]
    public class TestStructures
    {
        /// <summary>
        /// Tests Item structure Counter, CompareTo and TimeComplexity method
        /// </summary>
        [TestMethod]
        public void ItemTest()
        {
            Item<int> a = new Item<int>(1);
            Item<int> b = new Item<int>(1);
            Assert.AreEqual(a.CompareTo(b), 0);

            b.Value = 2;
            Assert.AreNotEqual(a.CompareTo(b), 0);
            Assert.AreEqual(a.CompareTo(b), -1);

            a.Value = 3;
            Assert.AreEqual(a.CompareTo(b), 1);

            Assert.AreEqual(a.Counter, 4);

            Item<int>[] array = { a, b };
            Assert.AreEqual(Item<int>.TimeComplexity(array), 8);
        }
    }
}
