using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Mercedes", "S-Class", 15, 300);
        }

        [Test]
        public void ConstructorShouldAddNewCarCorrectly()
        {
            Assert.IsNotNull(car);
        }

        [Test]
        public void MakeValidationShouldThrowExceptionWhenIsNull()
        {
            Assert.Throws<ArgumentException>(() => car = new Car(null, "S-Class", 15, 300));
        }

        [Test]
        public void ModelValidationShouldThrowExceptionWhenIsNull()
        {
            {
                Assert.Throws<ArgumentException>(() => car = new Car("Mercedes", null, 15, 300));
            }
        }

        [Test]
        public void FuelConsumptionValidationShouldThrowExceptionWhenIsBelow0()
        {
            {
                Assert.Throws<ArgumentException>(() => car = new Car("Mercedes", "S-Class", -2, 300));
            }
        }

        [Test]
        public void FuelCapacityValidationShouldThrowExceptionWhenIsBelow0()
        {
            {
                Assert.Throws<ArgumentException>(() => car = new Car("Mercedes", "S-Class", 50, 0));
            }
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelMethodShouldThrowExceptionWhenFuelIsEqualToOrBelow0(double fuel)
        {
            Assert.Throws<ArgumentException>(() => car.Refuel(fuel));
        }

        [Test]
        [TestCase(500)]
        public void RefuelMethodShouldRefuelCorrectly(double fuel)
        {
            car.Refuel(fuel);

            Assert.AreEqual(300, car.FuelAmount);
        }
        
        [Test]
        public void DriveMethodShouldReduceFuelAmountCorrectly()
        {
            car.Refuel(10);

            car.Drive(50);

            Assert.AreEqual(2.5, car.FuelAmount);
        }

        [Test]
        public void DriveMethodShouldThrowExceptionWhenFuelAmountIsLowerThanNeededFuel()
        {
            car.Refuel(5);

            Assert.Throws<InvalidOperationException>(() => car.Drive(50));
        }

        [Test]
        public void FuelAmountShouldBe0WhenInitialized()
        {
            Assert.AreEqual(0, car.FuelAmount);
        }
    }
}