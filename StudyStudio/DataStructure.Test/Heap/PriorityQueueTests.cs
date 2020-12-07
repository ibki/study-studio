using DataStructure.Heap;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataStructure.Test.Heap
{
    [TestClass]
    public class PriorityQueueTests
    {
        private readonly PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>();

        [TestMethod]
        [DataRow(5, 4, 3, 2, 1, 0)]
        [DataRow(1, 10, 2, 20, 3, 30)]
        [DataRow(1, 2, 3, 4, 5, 6)]
        [DataRow(50, 10, 5, 30, 40, 3)]
        [DataRow(30, 20, 1, 3, 60, 2)]
        [DataRow(23, 42, 4, 16, 8, 1, 3, 100, 5, 7)]
        public void Dequeue_RandomValues_ReturnsSortOfNumbers(params int[] values)
        {
            // Arrange
            foreach (var i in values)
            {
                priorityQueue.Enqueue(i, i);
            }
            var sortedValues = values.OrderBy(m => m).ToArray();


            // Act
            int index = 0;
            int[] actualValues = new int[priorityQueue.Count];
            while(!priorityQueue.IsEmpty)
            {
                actualValues[index++] = priorityQueue.Dequeue();
            }

            // Assert
            for (int i = 0; i < sortedValues.Length; i++)
            {
                Assert.AreEqual(sortedValues[i], actualValues[i]);
            }
        }
    }
}
