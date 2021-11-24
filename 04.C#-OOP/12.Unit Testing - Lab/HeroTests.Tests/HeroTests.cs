using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class HeroTests
    {
        [Test]
        public void HeroShouldGainsXPWhenTargetDies()
        {
            var fakeTarget = new Mock<ITarget>();
            var fakeWeapon = new Mock<IWeapon>();

            var hero = new Hero("Asen", fakeWeapon.Object);

            fakeTarget.Setup(p => p.IsDead()).Returns(true);
            fakeTarget.Setup(p => p.GiveExperience()).Returns(10);

            hero.Attack(fakeTarget.Object);

            Assert.AreEqual(fakeTarget.Object.GiveExperience(), hero.Experience);
        }
    }
}
