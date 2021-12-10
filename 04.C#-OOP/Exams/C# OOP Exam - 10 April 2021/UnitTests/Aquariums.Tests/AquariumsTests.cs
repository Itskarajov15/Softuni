namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {
        private Aquarium aquarium;
        private Fish fish;

        [SetUp]
        public void Setup()
        {
            this.aquarium = new Aquarium("Name", 50);
            this.fish = new Fish("Pesho");

            this.aquarium.Add(fish);
        }

        [Test]
        [TestCase(null, 50)]
        [TestCase("", 20)]
        public void ConstructorShouldThrowExceptionWhenNameIsInvalid(string name, int capacity)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, capacity));
        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenCapacityIsNegativeNumber()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("randomName", -1));
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenThereIsNoCapacity()
        {
            var aquarium = new Aquarium("Aquarium", 1);

            aquarium.Add(new Fish("Goshko"));

            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Lelq ti Goshka")));
        }

        [Test]
        public void AddMethodShouldAddFishCorrectly()
        {
            this.aquarium.Add(new Fish("Asen"));

            Assert.AreEqual(2, this.aquarium.Count);
        }

        [Test]
        public void RemoveFishMethodShouldThrowExceptionWhenFishDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.aquarium.RemoveFish("Gogi"));
        }

        [Test]
        public void RemoveFishMethodShouldRemoveFishCorrectly()
        {
            this.aquarium.RemoveFish("Pesho");

            Assert.AreEqual(0, this.aquarium.Count);
        }

        [Test]
        public void SellFishMethodShouldThrowExceptionWhenFishDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.aquarium.SellFish("Gogi"));
        }

        [Test]
        public void SellFishMethodShouldReturnFishCorrectly()
        {
            var returnedFish = this.aquarium.SellFish("Pesho");

            Assert.AreEqual(this.fish, returnedFish);
            Assert.AreEqual(1, this.aquarium.Count);
            Assert.False(this.fish.Available);
        }

        [Test]
        public void ReportMethodShouldReturnMessageCorrectly()
        {
            this.aquarium.Add(new Fish("Gosho"));

            var expected = "Fish available at Name: Pesho, Gosho";

            Assert.AreEqual(expected, this.aquarium.Report());
        }
    }
}
