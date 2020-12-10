using DataStructure.List;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataStructure.Heap
{
    public class BinaryHeap<T>
        where T : IComparable<T>
    {
        public SortOrder SortOrder { get; private set; }
        private readonly List<T> items = new List<T>();

        public int Count => items.Count;

        public bool IsEmpty => items.Count == 0;

        public T this[int index]
        {
            get
            {
                if (Count == 0 || index < 0 || Count < index)
                    throw new IndexOutOfRangeException();

                return items[index];
            }
            set
            {
                if (Count == 0 || index < 0 || Count < index)
                    throw new IndexOutOfRangeException();

                items[index] = value;

                if (index != 0 && IsSwap(Parent(index), index))
                    ShiftUp(index);
                else
                    Heapify(index);
            }
        }


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
            while (IsSwap(parent, index))
            {
                items.Swap(parent, index);

                index = parent;
                parent = Parent(index);
            }
        }

        private bool IsSwap(int parent, int index)
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

        /// <summary>
        /// Removing a item of index to the heap.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool Remove(int index)
        {
            int last = items.Count - 1;

            if (0 > index && last < index)
                return false;

            if (last == index)
                items.RemoveAt(index);
            else
            {
                items.Swap(index, last);
                items.RemoveAt(last);

                Heapify(index);
            }

            return true;
        }

        public void Heapify(int index)
        {
            int left = Left(index);
            int right = Right(index);
            int parent = index;

            if (left < Count && IsSwap(parent, left))
                parent = left;

            if (right < Count && IsSwap(parent, right))
                parent = right;

            if (parent != index)
            {
                items.Swap(index, parent);

                // Not parent index
                Heapify(parent);
            }
        }

        public T Peek() => IsEmpty ? throw new Exception("Heap is empty.") : items.First();

        public T ExtractFirst()
        {
            var first = Peek();

            Remove(0);

            return first;
        }

        public void Clear()
        {
            items.Clear();
        }

        public T[] ToArray() => items.ToArray();
    }
}
