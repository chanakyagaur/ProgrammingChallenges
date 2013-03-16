using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using AlgClass;

namespace MergeSort
{
    [TestFixture]
    public class MergeSortTests
    {
        [Test]
        public void Sort2ElementsArray()
        {
            long inversionCount;
            Assert.AreEqual("1,2", MergeSort.SortAndCount(new[] { 2, 1 }, out inversionCount).ToCustomString());
            Assert.AreEqual(1, inversionCount);
        }

        [Test]
        public void Sort3ElementsArray()
        {
            long inversionCount;
            Assert.AreEqual("1,2,3", MergeSort.SortAndCount(new[] { 3, 2, 1 }, out inversionCount).ToCustomString());
            Assert.AreEqual(3, inversionCount);
        }

        [Test]
        public void SortAlreadySortedArray()
        {
            long inversionCount;
            Assert.AreEqual("1,2,3,4,5", MergeSort.SortAndCount(new[] { 1, 2, 3, 4, 5 }, out inversionCount).ToCustomString());
            Assert.AreEqual(0, inversionCount);
        }

        [Test]
        public void Random6Array()
        {
            long inversionCount;
            Assert.AreEqual("1,2,3,4,5,6", MergeSort.SortAndCount(new[] { 1, 3, 5, 2, 4, 6 }, out inversionCount).ToCustomString());
            Assert.AreEqual(3, inversionCount);
        }

        [Test]
        public void SortEmptyArray()
        {
            long inversionCount;
            Assert.AreEqual("", MergeSort.SortAndCount(new int[0], out inversionCount).ToCustomString());
            Assert.AreEqual(0, inversionCount);
        }
    }
}
