const expect = require('chai').expect;
const cinema = require('./cinema.js');

describe("Tests", function () {
    describe("showMovies", function () {
        it("Should throw exception if input is empty array", function () {
            expect(cinema.showMovies([])).to.be.equal('There are currently no movies to show.');
        });

        it("Should return output correctly when input is valid", function () {
            expect(cinema.showMovies(['King Kong', 'The Tomorrow War', 'Joker'])).to.be.equal('King Kong, The Tomorrow War, Joker');
            expect(cinema.showMovies(['First Movie', 'Second Movie'])).to.be.equal('First Movie, Second Movie');
            expect(cinema.showMovies(['First Movie'])).to.be.equal('First Movie');
        });
    });

    describe("ticketPrice", function () {
        it("Should throw exception if projection type is invalid", function () {
            expect(() => cinema.ticketPrice('invalid input')).to.throw('Invalid projection type.');
            expect(() => cinema.ticketPrice('normal')).to.throw('Invalid projection type.');
        });

        it("Should return correct price if input is valid", function () {
            expect(cinema.ticketPrice('Premiere')).to.be.equal(12.00);
            expect(cinema.ticketPrice('Normal')).to.be.equal(7.50);
            expect(cinema.ticketPrice('Discount')).to.be.equal(5.50);
        });
    });

    describe("swapSeatsInHall", function () {
        it("Should return message if input is not a number", function () {
            expect(cinema.swapSeatsInHall('1', 15)).to.be.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(1, 'number')).to.be.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall('1', '15')).to.be.equal('Unsuccessful change of seats in the hall.');
        });

        it("Should return message if input is higher than 20", function () {
            expect(cinema.swapSeatsInHall(1, 21)).to.be.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(21, 5)).to.be.equal('Unsuccessful change of seats in the hall.');
        });

        it("Should return message if input is lower than 0", function () {
            expect(cinema.swapSeatsInHall(-1, 5)).to.be.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(19, -5)).to.be.equal('Unsuccessful change of seats in the hall.');
        });

        it("Should return message if one of the seats is equal to 0", function () {
            expect(cinema.swapSeatsInHall(0, 5)).to.be.equal('Unsuccessful change of seats in the hall.');
            expect(cinema.swapSeatsInHall(19, 0)).to.be.equal('Unsuccessful change of seats in the hall.');
        });

        it("Should return message if numbers are equal", function () {
            expect(cinema.swapSeatsInHall(5, 5)).to.be.equal('Unsuccessful change of seats in the hall.');
        });

        it("Should return correct message if places are swapped successfully", function () {
            expect(cinema.swapSeatsInHall(5, 6)).to.be.equal('Successful change of seats in the hall.');
        });

        it("Should return correct message if places are swapped successfully", function () {
            expect(cinema.swapSeatsInHall(1, 20)).to.be.equal('Successful change of seats in the hall.');
        });

        it("Should return message if one of the numbers does not exist", function () {
            expect(cinema.swapSeatsInHall(3)).to.be.equal('Unsuccessful change of seats in the hall.');
        });
    });
});