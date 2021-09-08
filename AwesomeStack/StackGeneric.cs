using System;

namespace AwesomeStack
{
    public sealed class Stack<T>
    {
        private readonly T[] items;

        public int Capacity { get; }

        public int Count { get; private set; }

        public bool IsEmpty => (Count == 0);

        public bool IsFull => (Count == Capacity);

        internal Stack(int capacity, int count = 0)
        {
            if (capacity == 0)
            {
                throw new ArgumentException("Cannot be zero.", nameof(capacity));
            }

            this.Capacity = capacity;
            this.Count = count;
            this.items = new T[capacity];
        }

        public void Push(T item)
        {
            if (IsFull)
            {
                throw new InvalidOperationException();
            }

            items[Count] = item;
            Count += 1;
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            Count -= 1;
            return items[Count];
        }
    }
}
