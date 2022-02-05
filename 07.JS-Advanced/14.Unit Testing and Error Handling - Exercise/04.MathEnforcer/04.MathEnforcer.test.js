const expect = require('chai').expect;
const mathEnforcer = require('./04.MathEnforcer');

describe('Math Enforcer', () => {
    it('Add five method should return undefined when parameter is not a number', () => {
        expect(mathEnforcer.addFive('text')).to.be.undefined;
    });

    it('Add five method should return result correctly when a valid parameter is passed', () => {
        expect(mathEnforcer.addFive(5)).to.be.equal(10);
    });

    it('Add five method should return result correctly when a negative number is passed', () => {
        expect(mathEnforcer.addFive(-5)).to.be.equal(0);
    });

    it('Add five method should return result correctly when a float number is passed', () => {
        expect(mathEnforcer.addFive(3.5)).to.be.closeTo(8.5, 0.01);
    });

    it('Subtract ten method should return undefined when parameter is not a number', () => {
        expect(mathEnforcer.subtractTen('text')).to.be.undefined;
    });

    it('Subtract ten method should return result correctly when a float number is passed', () => {
        expect(mathEnforcer.subtractTen(12.5)).to.be.closeTo(2.5, 0.01);
    });

    it('Subtract ten method should return result correctly when a negative number is passed', () => {
        expect(mathEnforcer.subtractTen(-10)).to.be.equal(-20);
    });

    it('Subtract ten method should return result correctly when a valid parameter is passed', () => {
        expect(mathEnforcer.subtractTen(20)).to.be.equal(10);
    });

    it('Sum method should return undefined when one of the parameters is not a number', () => {
        expect(mathEnforcer.sum('text', 1)).to.be.undefined;
        expect(mathEnforcer.sum(10, '1')).to.be.undefined;
        expect(mathEnforcer.sum('text', '1')).to.be.undefined;
    });

    it('Sum method should return result correctly when negative numbers are passed', () => {
        expect(mathEnforcer.sum(-5, - 20)).to.be.equal(-25);
    });

    it('Sum method should return result correctly when valid parameters are passed', () => {
        expect(mathEnforcer.sum(20, 10)).to.be.equal(30);
    });

    it('Sum method should return result correctly when float numbers are passed', () => {
        expect(mathEnforcer.sum(3.5, 7.2)).to.be.closeTo(10.7, 0.01);
    });
});