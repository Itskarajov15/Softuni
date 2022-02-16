const testNumbers = require('./testNumbers');
const expect = require('chai').expect;

describe("Tests …", function() {
    describe("sumNumbers test", function() {
        it("Should return undefined when input is invalid", function() {
            expect(testNumbers.sumNumbers(1, '2')).to.be.undefined;
        });
        
        it("Should return undefined when input is invalid", function() {
            expect(testNumbers.sumNumbers('1', 2)).to.be.undefined;
        });

        it("Should return undefined when input is invalid", function() {
            expect(testNumbers.sumNumbers('1', '2')).to.be.undefined;
        });

        it("Should return sum correctly when input is valid", function() {
            expect(testNumbers.sumNumbers(1, 2)).to.be.equal((3).toFixed(2));
        });

        it("Should return sum correctly when input is 0", function() {
            expect(testNumbers.sumNumbers(0, 0)).to.be.equal((0).toFixed(2));
        });

        it("Should return sum correctly when input is negative numbers", function() {
            expect(testNumbers.sumNumbers(-5, -15)).to.be.equal((-20).toFixed(2));
        });
    });
    
    describe("numberChecker test", function() {
        it("Should throw error when input is NaN", function() {
            expect(() => testNumbers.numberChecker('Hello')).to.throw('The input is not a number!');
        });

        it("Should return odd output when number is odd", function() {
            expect(testNumbers.numberChecker(1)).to.be.equal('The number is odd!');
        });

        it("Should return even output when number is even", function() {
            expect(testNumbers.numberChecker(2)).to.be.equal('The number is even!');
        });

        it("Should return even output when number is even and is negative number", function() {
            expect(testNumbers.numberChecker(-2)).to.be.equal('The number is even!');
        });

        it("Should return odd output when number is odd and is negative", function() {
            expect(testNumbers.numberChecker(-1)).to.be.equal('The number is odd!');
        });
    });

    describe("averageSumArray test", function() {
        it("Should calculate average sum when input is valid", function() {
            expect(testNumbers.averageSumArray([1, 2, 3])).to.be.equal(2);
        });
    });
});