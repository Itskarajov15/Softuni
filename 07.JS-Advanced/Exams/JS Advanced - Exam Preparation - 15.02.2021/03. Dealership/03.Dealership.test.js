const expect = require("chai").expect;
const dealership = require('./03.Dealership');

describe('Dealership', () => {
    it('New Car Cost method should return same new car price if the old car is not in the list', () => {
        expect(dealership.newCarCost('Lada', 100000)).to.be.equal(100000);
    });

    it('New Car Cost method should calculate and return correctly the new price if the old car is in the list', () => {
        expect(dealership.newCarCost('Audi A4 B8', 100000)).to.be.equal(85000);
    });

    it('Car Equipment method should return the extras correctly', () => {
        expect(dealership.carEquipment(['heated seats', 'sliding roof', 'sport rims', 'navigation'], [0, 3])).to.have.members(['heated seats', 'navigation']);
    });

    it('Euro Category method should return message correctly if category is low', () => {
        expect(dealership.euroCategory(1)).to.be.equal('Your euro category is low, so there is no discount from the final price!');
    });

    it('Euro Category method should calculate discount correctly if category is higher', () => {
        expect(dealership.euroCategory(5)).to.be.equal(`We have added 5% discount to the final price: ${14250}.`);
    });

    it('Euro Category method should calculate discount correctly if category is equal to 4', () => {
        expect(dealership.euroCategory(4)).to.be.equal(`We have added 5% discount to the final price: ${14250}.`);
    });
});