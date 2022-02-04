const isSymmetric = require('./05.CheckForSymmetry');
const expect = require('chai').expect;

describe('Check For Summetry', () => {
    it('Should return false if argument is not an array', () => {
        expect(isSymmetric(1)).to.be.false;
    });

    it('Should return true if input array is symmetric', () => {
        expect(isSymmetric([1, 1])).to.be.true;
    });

    it('Should return false if input array is not symmetric', () => {
        expect(isSymmetric([1, 2])).to.be.false;
    });

    it('Should return false for type-coersed elements', () => {
        expect(isSymmetric([1, '1'])).to.be.false;
    });
    
    it('Should return true for valid odd-element array', () => {
        expect(isSymmetric([1,1,1])).to.be.true;
    });

    it('Should return true for valid string array', () => {
        expect(isSymmetric(['a', 'a'])).to.be.true;
    });

    it('Should return false for valid string array', () => {
        expect(isSymmetric(['a', 'b'])).to.be.false;
    });
});