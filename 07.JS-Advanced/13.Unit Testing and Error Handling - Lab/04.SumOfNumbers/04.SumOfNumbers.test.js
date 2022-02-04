const expect = require('chai').expect;
const sum = require('./04.SumOfNumbers');

describe('Sum of Numbers', () => {
    it('Sum should be calculated properly with single number', () => {
        expect(sum([1])).to.equal(1);
    });

    it('Sum should be calculated properly with multiple numbers', () => {
        expect(sum([1, 1])).to.equal(2);
    });
});