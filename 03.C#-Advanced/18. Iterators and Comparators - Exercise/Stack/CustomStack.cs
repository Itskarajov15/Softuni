using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> elements;

        public CustomStack()
        {
            this.elements = new List<T>();
        }

        public void Push(List<T> elements)
        {
            foreach (var element in elements)
            {
                this.elements.Add(element);
            }
        }

        public void Pop()
        {
            if (this.elements.Count <= 0)
            {
                throw new InvalidOperationException("No elements");
            }
            else
            {
                this.elements.RemoveAt(this.elements.Count - 1);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.elements.Count - 1; i >= 0; i--)
            {
                yield return this.elements[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
