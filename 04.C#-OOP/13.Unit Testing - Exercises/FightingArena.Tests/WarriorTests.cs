using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Pesho", 30, 100);
        }

        [Test]
        [TestCase("Pesho", 20, 50)]
        public void ConstructorShouldSetEverythingIfDataIsValid(string name, int dmg, int hp)
        {
            var warrior = new Warrior(name, dmg, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(dmg, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        public void NameValidationShouldThrowExceptionIfIsNull()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(null, 50, 10));
        }

        [Test]
        public void DamageValidationShouldThrowExceptionIfIsEqualOrSmallerThan0()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Pesho", 0, 10));
        }

        [Test]
        public void HPValidationShouldThrowExceptionIfIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Pesho", 50, -1));
        }

        [Test]
        [TestCase(30)]
        [TestCase(25)]
        public void AttackMethodShouldThrowExceptionIfHPIsLowerOrEqualToMinAttackHP(int hp)
        {
            warrior = new Warrior("Pesho", 50, hp);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("Ivan", 50, 100)));
        }

        [Test]
        [TestCase(30)]
        [TestCase(25)]
        public void AttackMethodShouldThrowExceptionIfEnemyHPIsLowerOrEqualToMinAttackHP(int hp)
        {
            warrior = new Warrior("Pesho", 50, 100);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("Ivan", 50, hp)));
        }

        [Test]
        public void AttackMethodShouldThrowExceptionIfEnemyDamageIsGreater()
        {
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(new Warrior("Ivan", 150, 50)));
        }

        [Test]
        [TestCase("Pesho", 50, 100, 50,
                  "Gosho", 50, 100, 50)]
        [TestCase("Pesho", 100, 100, 50,
                  "Gosho", 50, 100, 0)]
        [TestCase("Pesho", 120, 100, 50,
                  "Gosho", 50, 100, 0)]
        public void AttackMethodShouldReduceHPForWarriorAndEnemyWarrior(
            string name
            , int damage
            , int health
            , int resultHp
            , string enemyName
            , int enemyDamage
            , int enemyHealth
            , int resultEnemyHp)
        {
            var myWarrior = new Warrior("Pesho", damage, health);
            var enemy = new Warrior("Gosho", enemyDamage, enemyHealth);

            myWarrior.Attack(enemy);

            Assert.AreEqual(resultHp, myWarrior.HP);
            Assert.AreEqual(resultEnemyHp, enemy.HP);
        }
    }
}