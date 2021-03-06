using System;
using System.Collections.Generic;
using System.Linq;

namespace ListIterator
{
    public class ListyIterator<T>
    {
        private int index;

        private List<T> elements;

        public ListyIterator(List<T> elements)
        {
            this.elements = new List<T>(elements);
            this.index = 0;
        }

        public ListyIterator(params T[] elements)
        {
            this.elements = new List<T>(elements);
        }

        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }

            return false;
        }

        public bool HasNext() => this.index < this.elements.Count - 1;

        public void Print()
        {
            if (this.elements.Count <= 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(this.elements[this.index]);
        }

        public void Create(params T[] elements)
        {
            this.elements = new List<T>(elements);
        }
    }
}
