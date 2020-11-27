using DataStructure.Heap;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataStructure.Test.Heap
{
    [TestClass]
    public class BinaryHeapTests
    {
        private readonly BinaryHeap<int> binaryIntMinHeap = new BinaryHeap<int>(SortOrder.Ascending);

        public BinaryHeapTests()
        {

        }

        [TestMethod]
        [DataRow(5, 4, 3, 2, 1)]
        [DataRow(1, 10, 2, 20, 3)]
        public void Add_RandomValues_ReturnsSortOfNumbers(params int[] values)
        {
            // Arrange
            binaryIntMinHeap.Clear();

            // Act
            foreach (var i in values)
            {
                binaryIntMinHeap.Add(i);
            }

            // Assert

        }

        public bool IsRightOrder<T>(BinaryHeap<T> binaryHeap)
            where T : IComparable<T>
        {
            var array = binaryHeap.ToArray();

            for (int i = 0; i * 2 + 1 < array.Length; i++)
            {
                int leftChildIndex = i * 2 + 1;
                int rightChildIndex = leftChildIndex + 1;


                if (array[i].CompareTo(array[leftChildIndex]) >= 0)
                {

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