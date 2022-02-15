const numberOperations = require('./03.NumberOperations');
const expect = require('chai').expect;

describe("Tests …", function() {
    describe("powNumber tests", function() {
        it("Should return power of a number correctly", function() {
            expect(numberOperations.powNumber(2)).to.be.equal(4);
        });
    });

    describe("numberChecker tests", function() {
        it("Should throw exception when input is NaN", function() {
            expect(() => numberOperations.numberChecker('asd')).to.throw('The input is not a number!');
        });

        it("Should return message correctly when input is valid and is lower than 100", function() {
            expect(numberOperations.numberChecker(50)).to.be.equal('The number is lower than 100!');
        });

        it("Should return message correctly when input is valid and is higher than 100", function() {
            expect(numberOperations.numberChecker(150)).to.be.equal('The number is greater or equal to 100!');
        });

        it("Should return message correctly when input is 100", function() {
            expect(numberOperations.numberChecker(100)).to.be.equal('The number is greater or equal to 100!');
        });
    });

    describe("sumArrays tests", function() {
        it("Should sum and return result correctly when the length of the arrays is the same", function() {
            expect(numberOperations.sumArrays([1, 2, 3], [1, 2, 3])).to.deep.equal([2, 4, 6]);
        });

        it("Should sum and return result correctly when the length of the arrays is different", function() {
            expect(numberOperations.sumArrays([1, 2, 3], [1, 2])).to.deep.equal([2, 4, 3]);
        });
    });
});