using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            warrior = new Warrior("Gosho", 50, 100);
            var warrior2 = new Warrior("Pesho", 10, 50);

            arena.Enroll(warrior);
            arena.Enroll(warrior2);
        }

        [Test]
        public void ConstructorShouldInitializeAllValues()
        {
            var arena = new Arena();

            Assert.IsNotNull(arena);
        }
        
        [Test]
        public void EnrollMethodShouldAddWarrioIfDoesntExist()
        {
            var arena = new Arena();
            var warrior = new Warrior("Gosho", 50, 100);

            arena.Enroll(warrior);

            Assert.AreEqual(1, arena.Count);

            bool warriorExist = arena.Warriors.Any(w => w.Name == warrior.Name);

            Assert.True(warriorExist);
        }

        [Test]
        public void EnrollMethodShouldThrowExceptionWhenWarriorIsAlreadyEnrolled()
        {
            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior));
        }

        [Test]
        [TestCase(null, "Ivan")]
        [TestCase("Ivan", null)]
        public void FightMethodShouldThrowExceptionWhenWarriorIsNotEnrolled(string attackerName, string deffenderName)
        {
            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, deffenderName));
        }

        [Test]
        public void FightMethodShouldThrowExceptionForInvalidAttacker()
        {
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Gogi", "Gosho"));
        }

        [Test]
        public void FightMethodShouldThrowExceptionForInvalidDeffender()
        {
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Gosho", "Gogi"));
        }
        
        [Test]
        public void FightMethodShouldReduceHp()
        {
            var attacker = new Warrior("Stoyan", 100, 50);
            var deffender = new Warrior("Kiro", 50, 100);

            arena.Enroll(attacker);
            arena.Enroll(deffender);

            arena.Fight("Stoyan", "Kiro");
        }
    }
}
