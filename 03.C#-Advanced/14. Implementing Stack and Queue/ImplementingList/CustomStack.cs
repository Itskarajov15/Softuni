using System;

namespace ImplementingList
{
    public class CustomStack
    {
        private const int InitialCapacity = 4;
        private int[] items;

        public CustomStack()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Push(int item)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        public int Pop()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            int itemToRemove = this.items[this.Count - 1];

            this.items[this.Count - 1] = default(int);

            this.Count--;

            if (this.Count == this.items.Length / 4)
            {
                this.Shrink();
            }

            return itemToRemove;
        }

        public int Peek()
        {
            if (this.Count <= 0)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return this.items[this.Count - 1];
        }

        public void Foreach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                action(this.items[i]);
            }
        }

        private void Shrink()
        {
            var copy = new int[this.items.Length / 2];

            Array.Copy(this.items, copy, this.Count);

            this.items = copy;
        }

        private void Resize()
        {
            var copy = new int[this.items.Length * 2];

            Array.Copy(this.items, copy, this.Count);

            this.items = copy;
        }
    }
}
