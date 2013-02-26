using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MergeSort
{
    [TestFixture]
    public class QuickSortTests
    {

        [Test]
        public void TwoElementsInOrder()
        {
            int comparisonCount = QuickSort.SortAndCountComparisons(Enumerable.Range(1, 2).ToArray(), PivotStrategy.First);

            Assert.AreEqual(1, comparisonCount);
        }

        [Test]
        public void TenElementsInOrder_PivotFirst()
        {
            int comparisonCount = QuickSort.SortAndCountComparisons(Enumerable.Range(1, 10).ToArray(), PivotStrategy.First);

            Assert.AreEqual(45, comparisonCount);
        }

        [Test]
        public void TenElementsInOrder_PivotLast()
        {
            int comparisonCount = QuickSort.SortAndCountComparisons(Enumerable.Range(1, 10).ToArray(), PivotStrategy.Last);

            Assert.AreEqual(45, comparisonCount);
        }

        [Test]
        public void TenElementsInOrder_PivotMedian()
        {
            int comparisonCount = QuickSort.SortAndCountComparisons(Enumerable.Range(1, 10).ToArray(), PivotStrategy.MedianOfTrhee);

            Assert.AreEqual(19, comparisonCount);
        }

        [Test]
        public void HundredElementsInOrder_PivotMedian()
        {
            int comparisonCount = QuickSort.SortAndCountComparisons(Enumerable.Range(1, 100).ToArray(), PivotStrategy.MedianOfTrhee);

            Assert.AreEqual(480, comparisonCount);
        }

        [Test]
        public void HundredElementsReverseOrder_PivotMedian()
        {
            int comparisonCount = QuickSort.SortAndCountComparisons(Enumerable.Range(1, 100).Reverse().ToArray(), PivotStrategy.MedianOfTrhee);

            Assert.AreEqual(1302, comparisonCount);
        }

        [Test]
        public void GetPivotIndex_SortedArray_First()
        {
            int pivotIndex = QuickSort.GetPivotIndex(new[] {1, 2, 3}, 0, 2, PivotStrategy.First);

            Assert.AreEqual(0, pivotIndex);
        }

        [Test]
        public void GetPivotIndex_SortedArray_Last()
        {
            int pivotIndex = QuickSort.GetPivotIndex(new[] { 1, 2, 3 }, 0, 2, PivotStrategy.Last);

            Assert.AreEqual(2, pivotIndex);
        }

        [Test]
        public void GetPivotIndex_SortedArray_Medium()
        {
            int pivotIndex = QuickSort.GetPivotIndex(new[] { 1, 2, 3 }, 0, 2, PivotStrategy.MedianOfTrhee);

            Assert.AreEqual(1, pivotIndex);
        }

        [Test]
        public void GetPivotIndex_UnSortedArray_Medium()
        {
            int pivotIndex = QuickSort.GetPivotIndex(new[] { 2, 1, 3 }, 0, 2, PivotStrategy.MedianOfTrhee);

            Assert.AreEqual(0, pivotIndex);

            pivotIndex = QuickSort.GetPivotIndex(new[] { 1, 3, 2 }, 0, 2, PivotStrategy.MedianOfTrhee);

            Assert.AreEqual(2, pivotIndex);

            pivotIndex = QuickSort.GetPivotIndex(new[] { 3, 1, 2 }, 0, 2, PivotStrategy.MedianOfTrhee);

            Assert.AreEqual(2, pivotIndex);
        }


        [Test]
        public void TenRandomOrder()
        {
            int count = QuickSort.SortAndCountComparisons(new[] { 2, 8, 9, 3, 7, 5, 10, 1, 6, 4 },PivotStrategy.MedianOfTrhee);

            Assert.AreEqual(19, count);

            count = QuickSort.SortAndCountComparisons(new[] { 2, 8, 9, 3, 7, 5, 10, 1, 6, 4 },PivotStrategy.First);

            Assert.AreEqual(25, count);

            count = QuickSort.SortAndCountComparisons(new[] { 2, 8, 9, 3, 7, 5, 10, 1, 6, 4 }, PivotStrategy.Last);

            Assert.AreEqual(20, count);
        }

        [Test]
        public void GetPivotIndex_UnSortedArray_Medium_4Elements()
        {
            int pivotIndex = QuickSort.GetPivotIndex(new[] { 2, 1, 3, 4 }, 0, 3, PivotStrategy.MedianOfTrhee);

            Assert.AreEqual(0, pivotIndex);

            pivotIndex = QuickSort.GetPivotIndex(new[] { 1, 3, 2, 4 }, 0, 3, PivotStrategy.MedianOfTrhee);

            Assert.AreEqual(1, pivotIndex);

            pivotIndex = QuickSort.GetPivotIndex(new[] { 3, 1, 2, 4 }, 0, 3, PivotStrategy.MedianOfTrhee);

            Assert.AreEqual(0, pivotIndex);

            pivotIndex = QuickSort.GetPivotIndex(new[] { 4, 1, 2, 3 }, 0, 3, PivotStrategy.MedianOfTrhee);

            Assert.AreEqual(3, pivotIndex);
        }
    }
}
