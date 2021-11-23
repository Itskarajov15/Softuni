using NUnit.Framework;
using System;
using System.Linq;

namespace DatabaseTests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1, 5)]
        [TestCase(1, 10)]
        [TestCase(1, 16)]
        public void ConstructorShouldAddNumbersWhileCountIsLessThan16(int start, int count)
        {
            var elements = Enumerable.Range(start, count).ToArray();
            
            var database = new Database(elements);

            Assert.AreEqual(count, database.Count);
        
        }

        [Test]
        [TestCase(1, 17)]
        [TestCase(1, 25)]
        public void ConstructorShouldThrowExceptionWhenCountIsBiggerThan16(int start, int count)
        {
            var elements = Enumerable.Range(start, count).ToArray();

            Assert.Throws<InvalidOperationException>(() => new Database(elements));
        }

        [Test]
        [TestCase(1, 17)]
        [TestCase(1, 25)]
        public void AddMethodShouldThrowExceptionIfCountIsBiggerThan16(int start, int count)
        {
            var elements = Enumerable.Range(start, count).ToArray();

            Assert.Throws<InvalidOperationException>(() => new Database(elements));
        }

        [Test]
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(16)]
        public void AddMethodShouldAddAllElementsWhiteCountIsLessThan16(int count)
        {
            var db = new Database();

            for (int i = 0; i < count; i++)
            {
                db.Add(i);
            }

            Assert.AreEqual(count, db.Count);
        }

        [Test]
        public void RemoveMethodShouldReduceCountWhenRemoveElement()
        {
            var db = new Database(new int[] { 2, 3, 4, 5, 6});

            db.Remove();
            db.Remove();

            Assert.AreEqual(3, db.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionWhenCountIs0()
        {
            var db = new Database();

            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void FetchMethodShouldReturnTheCorrectCollection()
        {
            var db = new Database(new int[] { 5, 6, 7, 8 });

            db.Add(5);
            db.Remove();
            db.Remove();

            var expectedCollection = new int[] { 5, 6, 7 };

            Assert.AreEqual(expectedCollection, db.Fetch());
        }
    }
}