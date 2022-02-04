const expect = require('chai').expect;
const createCalculator = require('./07.AddOrSubtract');

describe('Add or Subtract', () => {
    it('Sum functions should work correctly', () => {
        const calc = createCalculator();
        calc.add(12);
        let expected = 12;

        expect(calc.get()).to.equal(expected);
    });

    it('Subtract functions should work correctly', () => {
        const calc = createCalculator();
        calc.subtract(12);
        let expected = -12;

        expect(calc.get()).to.equal(expected);
    });

    it('Should return NaN for string argument added to add function', () => {
        const calc = createCalculator();

        calc.add('Hello');

        expect(calc.get()).to.be.NaN;
    });

    it('Should return value correctly', () => {
        const calc = createCalculator();

        calc.add(5);
        calc.add(6);
        calc.subtract(1);

        expect(calc.get()).to.be.equal(10);
    })

    it('Should return NaN for string argument added to subtract function', () => {
        const calc = createCalculator();

        calc.subtract('Hello');

        expect(calc.get()).to.be.NaN;
    });
});