const expect = require('chai').expect;
const flowerShop = require('./flowerShop.js');

describe("FlowerShop tests", function () {
    describe("calcPriceOfFlowers tests", function () {
        it("Should throw exception when type of flower is not a string", function () {
            expect(() => flowerShop.calcPriceOfFlowers(15, 15, 15)).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers([], 15, 15)).to.throw('Invalid input!');
        });

        it("Should throw exception when type of price is not a number", function () {
            expect(() => flowerShop.calcPriceOfFlowers('type', '2.5', 15)).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('type', [], 15)).to.throw('Invalid input!');
        });

        it("Should throw exception when type of quantity is not a number", function () {
            expect(() => flowerShop.calcPriceOfFlowers('type', 2.5, '15')).to.throw('Invalid input!');
            expect(() => flowerShop.calcPriceOfFlowers('type', 2.5, [])).to.throw('Invalid input!');
        });

        it("Should return correct output if parameters are valid", function () {
            expect(flowerShop.calcPriceOfFlowers('type', 20, 20)).to.be.equal(`You need $400.00 to buy type!`);
            expect(flowerShop.calcPriceOfFlowers('type', 15, 35)).to.be.equal(`You need $525.00 to buy type!`);
        });
    });

    describe("checkFlowersAvailable tests", function () {
        it("Should return correct output if flower is not in the array", function () {
            expect(flowerShop.checkFlowersAvailable('type', ["Rose", "Lily", "Orchid"])).to.be.equal(`The type are sold! You need to purchase more!`);
            expect(flowerShop.checkFlowersAvailable('Rose', ["Lily", "Orchid"])).to.be.equal(`The Rose are sold! You need to purchase more!`);
        });

        it("Should return correct output if flower is in the array", function () {
            expect(flowerShop.checkFlowersAvailable('Lily', ["Rose", "Lily", "Orchid"])).to.be.equal(`The Lily are available!`);
            expect(flowerShop.checkFlowersAvailable('Orchid', ["Rose", "Lily", "Orchid"])).to.be.equal(`The Orchid are available!`);
        });
    });

    describe("sellFlowers tests", function () {
        it("Should throw exception if input is invalid", function () {
            expect(() => flowerShop.sellFlowers('string', 15)).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers(15, 15)).to.throw('Invalid input!');
        });

        it("Should throw exception if input is invalid", function () {
            expect(() => flowerShop.sellFlowers([], 'number')).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers([], [])).to.throw('Invalid input!');
        });

        it("Should throw exception if space is lower than 0", function () {
            expect(() => flowerShop.sellFlowers([], -5)).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers([], -25)).to.throw('Invalid input!');
        });

        it("Should throw exception if space is higher than length of the array", function () {
            expect(() => flowerShop.sellFlowers(['firstType', 'secondType'], 50)).to.throw('Invalid input!');
            expect(() => flowerShop.sellFlowers(['firstType'], 2)).to.throw('Invalid input!');
        });

        it("Should return correct output if input is valid", function () {
            expect(flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], 1)).to.be.equal('Rose / Orchid');
            expect(flowerShop.sellFlowers(["Rose", "Lily", "Orchid"], 2)).to.be.equal('Rose / Lily');
        });
    });
});