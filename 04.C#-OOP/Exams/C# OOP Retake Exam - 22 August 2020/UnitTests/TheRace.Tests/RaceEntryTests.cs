using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        RaceEntry raceEntry;

        [SetUp]
        public void Setup()
        {
            raceEntry = new RaceEntry();
        }

        [Test]
        public void UnitCarConstructorShouldSetDataCorrectly()
        {
            var model = "Mercedes";
            var horsePower = 500;
            var cc = 6300;

            var car = new UnitCar(model, horsePower, cc);

            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(horsePower, car.HorsePower);
            Assert.AreEqual(cc, car.CubicCentimeters);
        }

        [Test]
        public void UnitDriverConstructorShouldSetDataCorrectly()
        {
            var name = "Lelq ti Goshka";
            var car = new UnitCar("Benz", 500, 6300);

            var driver = new UnitDriver(name, car);

            Assert.AreEqual(name, driver.Name);
            Assert.AreEqual(car, driver.Car);
        }

        [Test]
        public void AddDriverMethodShouldThrowExceptionWhenDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null));
        }

        [Test]
        public void AddDriverMethodShouldThrowExceptionWhenDriverAlreadyExists()
        {
            var driver = new UnitDriver("Pesho", new UnitCar("Benz", 500, 6300));

            raceEntry.AddDriver(driver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(driver));
        }

        [Test]
        public void AddDriverMethodShouldAddDriversCorrectly()
        {
            var driver = new UnitDriver("Pesho", new UnitCar("Benz", 500, 6300));

            raceEntry.AddDriver(driver);

            Assert.AreEqual(1, raceEntry.Counter);
        }

        [Test]
        public void AddDriverMethodShouldReturnTextIfDriverIsAdded()
        {
            var driver = new UnitDriver("Gosho", new UnitCar("Benz", 500, 6300));

            Assert.AreEqual("Driver Gosho added in race.", raceEntry.AddDriver(driver));
        }

        [Test]
        public void CalculateAverageHorsePowerMethodShouldThrowExceptionWhenThereAreNotEnoughParticipants()
        {
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePowerMethodShouldCalculateCorrectly()
        {
            var driver = new UnitDriver("Gosho", new UnitCar("Benz", 500, 6300));
            var driver2 = new UnitDriver("Ivan", new UnitCar("Lada", 90, 2000));
            var driver3 = new UnitDriver("Lelq ti Goshka", new UnitCar("Bavarkata", 160, 2500));

            var myList = new List<UnitDriver>();

            myList.Add(driver);
            myList.Add(driver2);
            myList.Add(driver3);

            raceEntry.AddDriver(driver);
            raceEntry.AddDriver(driver2);
            raceEntry.AddDriver(driver3);

            var myListAverage = myList
                .Select(d => d.Car.HorsePower)
                .Average();

            Assert.AreEqual(myListAverage, raceEntry.CalculateAverageHorsePower());
        }
    }
}