const expect = require('chai').expect;
const lookupChar = require('./03.CharLookup');

describe('Look up Char', () => {
    it('Should return undefined if first parameter is not a string', () => {
        expect(lookupChar({}, 1)).to.be.undefined;
    });

    it('Should return undefined if second parameter is not an integer', () => {
        expect(lookupChar('text', 'string')).to.be.undefined;
    });

    it('Should return undefined if second parameter is a float number', () => {
        expect(lookupChar('text', 3.14)).to.be.undefined;
    });

    it('Should return a message if index is out of bounds', () => {
        expect(lookupChar('text', 5)).to.be.equal('Incorrect index');
        expect(lookupChar('text', -1)).to.be.equal('Incorrect index');
    });

    it('Should return a correct output with valid parameters', () => {
        expect(lookupChar('text', 1)).to.be.equal('e');
        expect(lookupChar('mouse', 3)).to.be.equal('s');
    });
});