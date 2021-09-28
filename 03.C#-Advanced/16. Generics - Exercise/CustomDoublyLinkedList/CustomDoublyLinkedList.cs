using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class CustomDoublyLinkedList<T>
    {

        private bool reversed = false;
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            var node = new Node<T>(element);

            Count++;

            if (Head == null)
            {
                Head = Tail = node;
                return;
            }

            node.Next = Head;
            Head.Previous = node;
            Head = node;
        }

        public void AddLast(T element)
        {
            var node = new Node<T>(element);

            Count++;

            if (Tail == null)
            {
                Head = Tail = node;
                return;
            }

            node.Previous = Tail;
            Tail.Next = node;
            Tail = node;
        }

        public T RemoveFirst()
        {
            if (Count <= 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var firstElement = Head.Value;
            Head = Head.Next;

            if (Head != null)
            {
                Head.Previous = null;
            }
            else
            {
                Tail = null;
            }

            Count--;

            return firstElement;
        }

        public T RemoveLast()
        {
            if (Count <= 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var lastElement = Tail.Value;
            Tail = Tail.Previous;

            if (Tail != null)
            {
                Tail.Next = null;
            }
            else
            {
                Head = null;
            }

            Count--;

            return lastElement;
        }

        public void ForEach(Action<T> action)
        {
            var currNode = Head;

            while (currNode != null)
            {
                action(currNode.Value);

                if (reversed)
                {
                    currNode = currNode.Previous;
                }
                else
                {
                    currNode = currNode.Next;
                }
            }
        }

        public T[] ToArray()
        {
            var array = new T[Count];
            var counter = 0;

            var currNode = Head;

            while (currNode != null)
            {
                array[counter] = currNode.Value;
                currNode = currNode.Next;
                counter++;
            }

            return array;
        }

        public void Reverse()
        {
            var temp = Head;
            Head = Tail;
            Tail = temp;

            reversed = !reversed;
        }
    }
}
