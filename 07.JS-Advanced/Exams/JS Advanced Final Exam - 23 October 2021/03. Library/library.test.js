const expect = require('chai').expect;
const library = require('./library.js');

describe("Library tests", function () {
    describe("calcPriceOfBook tests", function () {
        it("Should throw error if input is invalid", function () {
            expect(() => library.calcPriceOfBook('name', 'year')).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook(15, 2000)).to.throw('Invalid input');
            expect(() => library.calcPriceOfBook(15, 'year')).to.throw('Invalid input');
        });

        it("Should return output correctly when input is valid and year is before 1980", function () {
            expect(library.calcPriceOfBook('book', 1979)).to.be.equal(`Price of book is 10.00`);
        });

        it("Should return output correctly when input is valid and year is 1980", function () {
            expect(library.calcPriceOfBook('book', 1980)).to.be.equal(`Price of book is 10.00`);
        });

        it("Should return output correctly when input is valid and year after 1980", function () {
            expect(library.calcPriceOfBook('book', 1981)).to.be.equal(`Price of book is 20.00`);
        });

        it("Should return output correctly when input is valid and year after 1980", function () {
            expect(library.calcPriceOfBook('book', 2002)).to.be.equal(`Price of book is 20.00`);
        });
    });

    describe("findBook tests", function () {
        it("Should throw error if array is empty", function () {
            expect(() => library.findBook([], 'book')).to.throw('No books currently available');
        });

        it("Should return correct output if input is valid and book is not in the array", function () {
            expect(library.findBook(['firstName', 'secondName'], 'book')).to.be.equal('The book you are looking for is not here!');
        });

        it("Should return correct output if input is valid and book is in the array", function () {
            expect(library.findBook(['firstName', 'secondName', 'book'], 'book')).to.be.equal('We found the book you want.');
        });
    });

    describe("arrangeTheBooks tests", function () {
        it("Should throw error if count of books is not a number", function () {
            expect(() => library.arrangeTheBooks('number')).to.throw('Invalid input');
        });

        it("Should throw error if count of books is lower than 0", function () {
            expect(() => library.arrangeTheBooks(-1)).to.throw('Invalid input');
        });

        it("Should work correctly when count of books is 0", function () {
            expect(library.arrangeTheBooks(0)).to.be.equal('Great job, the books are arranged.');
        });

        it("Should work correctly when count of books is valid number and there is enough free space", function () {
            expect(library.arrangeTheBooks(15)).to.be.equal('Great job, the books are arranged.');
        });

        it("Should work correctly when count of books is valid number and there is not enough free space", function () {
            expect(library.arrangeTheBooks(100)).to.be.equal('Insufficient space, more shelves need to be purchased.');
        });

        it("Should work correctly when count of books is 40", function () {
            expect(library.arrangeTheBooks(40)).to.be.equal('Great job, the books are arranged.');
        });

        it("Should work correctly when count of books is valid number and there is not enough free space", function () {
            expect(library.arrangeTheBooks(41)).to.be.equal('Insufficient space, more shelves need to be purchased.');
        });
    });
});