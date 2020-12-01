using DataStructure.List;
using System;
using System.Collections.Generic;

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

        private int Parent(int index) => (index - 1) / 2;
        private int Left(int index) => (index * 2) + 1;
        private int Right(int index) => Left(index) + 1;

        private void ShiftUp(int index)
        {
            int parent = Parent(index);
            while (CompareWhenShiftUp(parent, index))
            {
                items.Swap(parent, index);

                index = parent;
                parent = Parent(index);
            }
        }

        // TODO: Method name is not clear
        private bool CompareWhenShiftUp(int parent, int index)
            => SortOrder == SortOrder.Ascending ?
               items[parent].CompareTo(items[index]) > 0 :
               items[parent].CompareTo(items[index]) < 0;

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

        public void Clear()
        {
            items.Clear();
        }

        public T[] ToArray() => items.ToArray();
    }
}
