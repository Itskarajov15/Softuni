const expect = require('chai').expect;
const isOddOrEven = require('./02.EvenOrOdd');

describe('Even or Odd', () => {
    it('Should return undefined when a non string argument is passed', () => {
        expect(isOddOrEven(1)).to.be.undefined;
        expect(isOddOrEven([])).to.be.undefined;
    });

    it('Should return even when a valid argument with even length is passed', () => {
        expect(isOddOrEven('word')).to.be.equal('even');
    });

    it('Should return odd when a valid argument with odd length is passed', () => {
        expect(isOddOrEven('mouse')).to.be.equal('odd');
    });

    it('Should return odd when a valid argument with odd length is passed', () => {
        expect(isOddOrEven('pad')).to.be.equal('odd');
    });

    it('Should return even when a valid argument with even length is passed', () => {
        expect(isOddOrEven('test')).to.be.equal('even');
    });
});