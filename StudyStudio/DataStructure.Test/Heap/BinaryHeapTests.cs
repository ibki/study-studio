using DataStructure.Heap;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructure.Test.Heap
{
    [TestClass]
    public class BinaryHeapTests
    {
        private readonly BinaryHeap<>

        public BinaryHeapTests()
        {

        }

        [TestMethod]
        [DataRow(5, 4, 3, 2, 1)]
        [DataRow(1, 10, 2, 20, 3)]
        public void Add_RandomValues_ReturnsSortOfNumbers(params int[] values)
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
