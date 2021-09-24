using System;
using System.Collections.Generic;
using System.Text;

namespace ImplementingList
{
    public class CustomList
    {
        private int[] items;
        public const int InitialCapacity = 2;

        public CustomList()
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                ValidateIndex(index);

                return this.items[index];
            }

            set
            {
                ValidateIndex(index);

                this.items[index] = value;
            }
        }

        public void Add(int item)
        {
            if (this.Count >= this.items.Length)
            {
                this.Resize();
            }

            this.items[this.Count] = item;
            this.Count++;
        }

        public int RemoveAt(int index)
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            int numberToRemove = this.items[index];
            this.items[index] = default(int);
            this.Shift(index);

            this.Count--;
            if (this.Count == this.items.Length / 4)
            {
                this.Shrink();
            }

            return numberToRemove;
        }

        public void InsertAt(int index, int item)
        {
            if (index > this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (this.Count == this.items.Length)
            {
                this.Resize();
            }

            this.ShiftRight(index);
            this.items[index] = item;
            this.Count++;
        }

        public bool Contains(int number)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == number)
                {
                    return true;
                }
            }

            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            ValidateIndex(firstIndex);
            ValidateIndex(secondIndex);

            var temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }

        private void ValidateIndex(int index)
        {
            if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private void Resize()
        {
            var copy = new int[this.Count * 2];

            Array.Copy(this.items, copy, this.Count);

            this.items = copy;
        }

        private void Shift(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[index] = this.items[index + 1];
            }
        }

        private void Shrink()
        {
            var copy = new int[this.items.Length / 2];

            Array.Copy(this.items, copy, this.Count);

            this.items = copy;
        }

        private void ShiftRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
    }
}
