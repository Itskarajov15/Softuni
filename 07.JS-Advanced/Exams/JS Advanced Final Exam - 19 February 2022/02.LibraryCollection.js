class LibraryCollection {
    constructor(capacity) {
        this.capacity = capacity;
        this.books = [];
    }

    addBook(bookName, bookAuthor) {
        if (this.books.length >= this.capacity) {
            throw new Error('Not enough space in the collection.');
        }

        let currBook = {
            bookName,
            bookAuthor,
            payed: false
        }

        this.books.push(currBook);

        return `The ${bookName}, with an author ${bookAuthor}, collect.`;
    }

    payBook(bookName) {
        if (!this.books.find(b => b.bookName === bookName)) {
            throw new Error(`${bookName} is not in the collection.`);
        }

        let currBook = this.books.find(b => b.bookName === bookName);

        if (currBook.payed === true) {
            throw new Error(`${bookName} has already been paid.`);
        }

        currBook.payed = true;

        return `${bookName} has been successfully paid.`;
    } 

    removeBook(bookName) {
        if (!this.books.find(b => b.bookName === bookName)) {
            throw new Error('The book, you\'re looking for, is not found.');
        }

        let currBook = this.books.find(b => b.bookName === bookName);

        if (currBook.payed === false) {
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        }

        this.books = this.books.filter(b => b.bookName !== bookName);

        return `${bookName} remove from the collection.`;
    }

    getStatistics(bookAuthor) {
        let result = [];

        if (bookAuthor) {
            let booksFromGivenAuthor = this.books
                .filter(b => b.bookAuthor === bookAuthor);

            if (booksFromGivenAuthor.length <= 0) {
                throw new Error(`${bookAuthor} is not in the collection.`);
            }

            booksFromGivenAuthor.forEach(b => {
                result.push(`${b.bookName} == ${b.bookAuthor} - ${b.payed === true ? 'Has Paid' : 'Not Paid'}.`);
            });
        } else {
            result.push(`The book collection has ${this.capacity - this.books.length} empty spots left.`);
            this.books
                .sort((a, b) => a.bookName.localeCompare(b.bookName))
                .forEach(b => {
                    result.push(`${b.bookName} == ${b.bookAuthor} - ${b.payed === true ? 'Has Paid' : 'Not Paid'}.`);
                });
        }

        return result.join('\n');
    }
}

const library = new LibraryCollection(5)
library.addBook('Don Quixote', 'Miguel de Cervantes');
library.payBook('Don Quixote');
library.addBook('In Search of Lost Time', 'Marcel Proust');
library.addBook('Ulysses', 'James Joyce');
console.log(library.getStatistics());