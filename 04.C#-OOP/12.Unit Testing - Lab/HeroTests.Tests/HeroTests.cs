using NUnit.Framework;
using Skeleton.Fakes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroTests.Tests
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void HeroShouldGainsXPWhenTargetDies()
        {
            var fakeTarget = new FakeTarget();
            var fakeWeapon = new FakeWeapon();

            var hero = new Hero("Gosho", fakeWeapon);

            hero.Attack(fakeTarget);

            Assert.AreEqual(fakeTarget.GiveExperience(), hero.Experience);
        }
    }
}
