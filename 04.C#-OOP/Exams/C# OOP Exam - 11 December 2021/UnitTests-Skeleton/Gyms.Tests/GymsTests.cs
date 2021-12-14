using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        private Gym gym;
        private Athlete athlete;

        [SetUp]
        public void Setup()
        {
            this.gym = new Gym("Build", 100);
            this.athlete = new Athlete("Stamat");

            this.gym.AddAthlete(athlete);
        }

        [Test]
        [TestCase(null, 100)]
        [TestCase("", 100)]
        public void ConstructorShouldThrowExceptionWhenNameIsInvalid(string name, int size)
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(name, size));
        }

        [Test]
        public void ConstructorShouldThrowExceptionWhenCapacityIsInvalid()
        {
            Assert.Throws<ArgumentException>(() => new Gym("Name", -1));
        }

        [Test]
        public void AddAthleteMethodShouldThrowExceptionWhenGymIsFull()
        {
            var myGym = new Gym("Gym", 0);

            Assert.Throws<InvalidOperationException>(() => myGym.AddAthlete(new Athlete("Gosho")));
        }

        [Test]
        public void AddAthleteMethodShouldAddAthletesCorrectly()
        {
            var athlete = new Athlete("Pesho");

            this.gym.AddAthlete(athlete);

            Assert.AreEqual(2, this.gym.Count);
        }

        [Test]
        public void RemoveAthleteMethodShouldThrowExceptionWhenAthleteDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.gym.RemoveAthlete("Lelq ti Goshka"));
        }

        [Test]
        public void RemoveAthleteMethodShouldRemoveAthletesCorrectly()
        {
            this.gym.RemoveAthlete("Stamat");

            Assert.AreEqual(0, this.gym.Count);
        }

        [Test]
        public void InjureAthleteMethodShouldThrowExceptionWhenAthleteDoesntExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.gym.InjureAthlete("Lelq ti Goshka"));
        }

        [Test]
        public void InjureAthleteMethodShouldInjureAthlete()
        {
            Athlete ath = new Athlete("Ginka");
            this.gym.AddAthlete(ath);

            this.gym.InjureAthlete("Ginka");

            Assert.True(ath.IsInjured);
        }

        [Test]
        public void InjureAthleteMethodShouldReturnAthleteCorrectly()
        {
            Athlete randomAthlete = new Athlete("Goshko");

            this.gym.AddAthlete(randomAthlete);

            var result = this.gym.InjureAthlete("Goshko");

            Assert.AreEqual(randomAthlete, result);
        }

        [Test]
        public void ReportMethodShouldReturnDataCorrectly()
        {
            var newGym = new Gym("Name", 5);

            var athlete1 = new Athlete("Lelq ti Goshka");
            var athlete2 = new Athlete("Goshko");

            newGym.AddAthlete(athlete1);
            newGym.AddAthlete(athlete2);

            var expected = "Active athletes at Name: Lelq ti Goshka, Goshko";

            var result = newGym.Report();

            Assert.AreEqual(expected, result);
        }
    }
}
