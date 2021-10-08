using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.Books = new SortedSet<Book>(books, new BookComparator());
        }

        private SortedSet<Book> Books;

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(Books);
        }
        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;

            public Book Current => this.books[currentIndex];

            object IEnumerator.Current => this.Current;

            public LibraryIterator(IEnumerable<Book> books)
            {
                Reset();
                this.books = new List<Book>(books);
            }

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                this.currentIndex++;

                if (this.currentIndex < this.books.Count)
                {
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                currentIndex = -1;
            }
        }
    }
}
