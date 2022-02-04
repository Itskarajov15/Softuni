const rgbToHexColor = require('./06.RGBToHex');
const expect = require('chai').expect;

describe('RGB to Hex', () => {
    it('Should return undefined when invalid argument is passed', () => {
        expect(rgbToHexColor(-1, 5, 0)).to.be.undefined;
        expect(rgbToHexColor(256, 5, 0)).to.be.undefined;
        expect(rgbToHexColor(1, -10, 0)).to.be.undefined;
        expect(rgbToHexColor(1, 300, 0)).to.be.undefined;
        expect(rgbToHexColor(1, 5, -20)).to.be.undefined;
        expect(rgbToHexColor(1, 5, 2000)).to.be.undefined;
        expect(rgbToHexColor('asen', 5, 0)).to.be.undefined;
        expect(rgbToHexColor(-1, 'asen', 0)).to.be.undefined;
        expect(rgbToHexColor(-1, 5, 'asen')).to.be.undefined;
        expect(rgbToHexColor(5.2, 5, 0)).to.be.undefined;
        expect(rgbToHexColor(1, 4.3, 0)).to.be.undefined;
        expect(rgbToHexColor(2, 5, 7.8)).to.be.undefined;
    });

    it('Should return a color correctly', () => {
        expect(rgbToHexColor(245, 45, 65)).to.be.equal('#F52D41');
    });

    it('Should return a white', () => {
        expect(rgbToHexColor(255, 255, 255)).to.be.equal('#FFFFFF');
    });

    it('Should return a black', () => {
        expect(rgbToHexColor(0, 0, 0)).to.be.equal('#000000');
    });
});