using NUnit.Framework;
using System;

namespace TestAxe.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void WeaponShouldLoseDurabiltyAfterAttack()
        {
            var axe = new Axe(10, 10);
            var dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.AreEqual(9, axe.DurabilityPoints);
        }

        [Test]
        public void WeaponShouldNotAttackWhenIsBroked()
        {
            var axe = new Axe(10, 0);
            var dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}
