using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DataStructure.Heap
{
    public class PriorityQueue<TKey, TPriority>
        where TKey : IComparable<TKey>
        where TPriority : IComparable<TPriority>
    {
        private readonly BinaryHeap<PriorityQueueNode<TKey, TPriority>> binaryHeap
            = new BinaryHeap<PriorityQueueNode<TKey, TPriority>>(SortOrder.Ascending);

        public int Count => binaryHeap.Count;

        public bool IsEmpty => binaryHeap.IsEmpty;

        public bool Enqueue(TKey key, TPriority priority)
        {
            binaryHeap.Add(new PriorityQueueNode<TKey, TPriority>(key, priority));

            return true;
        }

        public TKey Dequeue()
        {
            if (binaryHeap.IsEmpty)
                throw new ArgumentOutOfRangeException("Queue is empty.");

            return binaryHeap.ExtractFirst().Key;
        }

        public void Clear()
        {
            binaryHeap.Clear();
        }
    }

    public class PriorityQueueNode<TKey, TPriority> : IComparable<PriorityQueueNode<TKey, TPriority>>
        where TKey : IComparable<TKey>
        where TPriority : IComparable<TPriority>
    {
        public TKey Key { get; set; }
        public TPriority Priority { get; set; }

        public PriorityQueueNode(TKey key, TPriority priority)
        {
            Key = key;
            Priority = priority;
        }

        public int CompareTo(PriorityQueueNode<TKey, TPriority> other)
        {
            return Priority.CompareTo(other.Priority);
        }
    }
}
