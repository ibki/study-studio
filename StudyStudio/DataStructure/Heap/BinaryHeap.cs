using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Heap
{

    public class BinaryHeap<T>
        where T : IComparable<T>
    {
        public SortOrder SortOrder { get; private set; }
        private readonly List<T> items = new List<T>();

        public BinaryHeap(SortOrder sortOrder)
        {
            SortOrder = sortOrder;
        }

        private void ShiftUp(int index)
        {
            int parent = index / 2;
            if (SortOrder == SortOrder.Ascending)
            while (items[parent].CompareTo(items[index]) < 0)
            else
            while (items[parent].CompareTo(items[index]) < 0)
            {

            }
        }

        private bool CompareWhenShiftUp(int parent, int index)
            => SortOrder == SortOrder.Ascending ?
               items[parent].CompareTo(items[index]) < 0 :
               items[parent].CompareTo(items[index]) > 0;

        /// <summary>
        /// Adding a new item to the heap.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Add(T item)
        {
            items.Add(item);

            ShiftUp(items.Count - 1);

            return true;
        }
    }
}
