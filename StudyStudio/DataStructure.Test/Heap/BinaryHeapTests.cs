using DataStructure.Heap;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DataStructure.Test.Heap
{
    [TestClass]
    public class BinaryHeapTests
    {
        private readonly BinaryHeap<int> binaryIntMinHeap = new BinaryHeap<int>(SortOrder.Ascending);
        private readonly BinaryHeap<int> binaryIntMaxHeap = new BinaryHeap<int>(SortOrder.Descending);

        public BinaryHeapTests()
        {

        }

        [TestMethod]
        [DataRow(5, 4, 3, 2, 1, 0)]
        [DataRow(1, 10, 2, 20, 3, 30)]
        [DataRow(1, 2, 3, 4, 5, 6)]
        [DataRow(50, 10, 5, 30, 40, 3)]
        [DataRow(30, 20, 1, 3, 60, 2)]
        [DataRow(23, 42, 4, 16, 8, 1, 3, 100, 5, 7)]
        public void Add_RandomValues_ReturnsSortOfNumbers(params int[] values)
        {
            // Arrange
            binaryIntMinHeap.Clear();
            binaryIntMaxHeap.Clear();

            // Act
            foreach (var i in values)
            {
                binaryIntMinHeap.Add(i);
                binaryIntMaxHeap.Add(i);
            }

            // Assert
            Assert.IsTrue(IsRightOrder(binaryIntMinHeap));
            Assert.IsTrue(IsRightOrder(binaryIntMaxHeap));
        }

        [TestMethod]
        [DataRow(5, 4, 3, 2, 1, 0)]
        [DataRow(1, 10, 2, 20, 3, 30)]
        [DataRow(1, 2, 3, 4, 5, 6)]
        [DataRow(50, 10, 5, 30, 40, 3)]
        [DataRow(30, 20, 1, 3, 60, 2)]
        [DataRow(23, 42, 4, 16, 8, 1, 3, 100, 5, 7)]
        public void Remove_RandomValues_ReturnsSortOfNumbers(params int[] values)
        {
            // Arrange
            binaryIntMinHeap.Clear();
            binaryIntMaxHeap.Clear();
            foreach (var i in values)
            {
                binaryIntMinHeap.Add(i);
                binaryIntMaxHeap.Add(i);
            }

            // Act & Assert
            binaryIntMinHeap.Remove(1);
            binaryIntMaxHeap.Remove(1);
            Assert.IsTrue(IsRightOrder(binaryIntMinHeap));
            Assert.IsTrue(IsRightOrder(binaryIntMaxHeap));

            binaryIntMinHeap.Remove(2);
            binaryIntMaxHeap.Remove(2);
            Assert.IsTrue(IsRightOrder(binaryIntMinHeap));
            Assert.IsTrue(IsRightOrder(binaryIntMaxHeap));
        }

        public bool IsRightOrder<T>(BinaryHeap<T> binaryHeap)
            where T : IComparable<T>
        {
            var array = binaryHeap.ToArray();

            for (int i = 0; i * 2 + 1 < array.Length; i++)
            {
                int leftChildIndex = i * 2 + 1;
                int rightChildIndex = leftChildIndex + 1;

                if (!IsCompare(array[i], array[leftChildIndex], binaryHeap.SortOrder))
                    return false;

                if (rightChildIndex < array.Length)
                {
                    if (!IsCompare(array[i], array[rightChildIndex], binaryHeap.SortOrder))
                        return false;
                }    
            }

            return true;
        }

        public bool IsCompare<T>(T a, T b, SortOrder sortOrder) where T : IComparable<T>
            => sortOrder == SortOrder.Ascending ?
               a.CompareTo(b) <= 0 :
               a.CompareTo(b) >= 0;
    }
}