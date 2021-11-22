using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DummyTests.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyShouldLoseHealthWhenAttacked()
        {
            var dummy = new Dummy(10, 10);

            dummy.TakeAttack(5);

            Assert.AreEqual(5, dummy.Health, "Dummy doesn't lose health.");
        }

        [Test]
        public void DeadDummyShouldThrowExceptionIfAttacked()
        {
            var dummy = new Dummy(0, 5);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(5), "Dead dummy doesn't throw an exception.");
        }

        [Test]
        public void DeadDummyShouldReturnExperience()
        {
            var dummy = new Dummy(0, 5);

            Assert.AreEqual(5, dummy.GiveExperience(), "Dead dummy doesn't return experience.");
        }

        [Test]
        public void AliveDummyShouldNotReturnExperience()
        {
            var dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Alive dummy return experience.");
        }
    }
}
