using NUnit.Framework;
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
            var hero = new Hero("Name", new Axe(10, 10));

            var dummy = new Dummy(1, 10);

            hero.Attack(dummy);

            Assert.AreEqual(10, hero.Experience);
        }
    }
}
