using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        ExtendedDatabase db = null;
        Person person = null;

        [SetUp]
        public void Setup()
        {
            person = new Person(124214, "Pesho");
            db = new ExtendedDatabase(person);
        }

        [Test]
        public void ConstructorShouldInitializeDataCorrectly()
        {
            Assert.IsNotNull(db);
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfPersonWithSameUsernameExists()
        {
            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(124124, "Pesho")));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfPersonWithSameIdExists()
        {
            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(124214, "Ivan")));
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfCountIsZero()
        {
            var database = new ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void RemoveMethodShouldRemovePeopleCorrectly()
        {
            db.Add(new Person(123123213213, "Ivan"));

            db.Remove();

            Assert.AreEqual(1, db.Count);
            Assert.Throws<InvalidOperationException>(() => db.FindById(123123213213));
        }

        [Test]
        public void FindByUsernameMethodShouldThrowExceptionIfNameIsNull()
        {
            var database = new ExtendedDatabase();

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
        }

        [Test]
        [TestCase("Lelq ti Goshka")]
        [TestCase("Ginka")]
        public void FindByUsernameMethodShouldThrowExceptionIfNoSuchPersonExists(string name)
        {
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername(name));
        }

        [Test]
        public void FindByIdShouldThrowExceptionIfIdIsNegativeNumber()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-1));
        }

        [Test]
        public void FindByIdShouldThrowExceptionIfPersonWithSameIdDoesntExists()
        {
            Assert.Throws<InvalidOperationException>(() => db.FindById(69));
        }

        [Test]
        [TestCase(111, "Penka")]
        public void FingByIdShouldReturnDataCorretly(int id, string name)
        {
            var person = new Person(id, name);

            db.Add(person);

            Assert.AreEqual(person, db.FindById(id));
        }

        [Test]
        [TestCase(111, "Penka")]
        public void FingByUsernameShouldReturnDataCorretly(int id, string name)
        {
            var person = new Person(id, name);

            db.Add(person);

            Assert.AreEqual(person, db.FindByUsername(name));
        }

        [Test]
        public void AddRangeMethodShouldThrowExceptionIfCountIsBiggerThan16()
        {
            var peopleToAdd = new List<Person>();
            var name = String.Empty;

            for (int i = 0; i < 17; i++)
            {
                peopleToAdd.Add(new Person(i, name + i));
            }

            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(peopleToAdd.ToArray()));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfCountIsBiggerThan16()
        {
            var database = new ExtendedDatabase();
            var name = String.Empty;

            for (int i = 0; i < 16; i++)
            {
                database.Add(new Person(i, name + i));
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(person));
        }
    }
}