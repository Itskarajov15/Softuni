using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class BoxOfT<T>
    {
        List<T> elements;

        public BoxOfT()
        {
            this.elements = new List<T>();
        }

        public int Count
        {
            get => this.elements.Count;
        }

        public void Add(T element)
        {
            this.elements.Add(element);
        }

        public T Remove()
        {
            var itemToRemove = this.elements.Last();

            this.elements.RemoveAt(this.elements.Count - 1);

            return itemToRemove;
        }
    }
}
