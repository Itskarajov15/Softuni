using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainblock;

        [SetUp]
        public void Setup()
        {
            chainblock = new Chainblock();
        }

        [Test]
        public void AddMethodShouldAddTransactionsCorrectly()
        {
            ITransaction transaction = new Transaction(123, TransactionStatus.Successfull,
                "Asen", "Gosho", 50);

            chainblock.Add(transaction);
            var exist = chainblock.Contains(transaction);

            Assert.True(exist);
            Assert.AreEqual(1, chainblock.Count);
        }

        [Test]
        public void AddMethodShouldAddOnlyUniqueTransactions()
        {
            ITransaction transaction = new Transaction(123, TransactionStatus.Successfull,
                "Asen", "Gosho", 50);

            chainblock.Add(transaction);
            chainblock.Add(transaction);

            Assert.AreEqual(1, chainblock.Count);
        }

        [Test]
        public void ChangeTransactionStatusMethodShouldChangeStatusCorrectly()
        {
            ITransaction transaction = new Transaction(123, TransactionStatus.Successfull,
                "Asen", "Gosho", 50);

            chainblock.Add(transaction);

            var currTransaction = chainblock.GetById(123);

            chainblock.ChangeTransactionStatus(123, TransactionStatus.Failed);

            Assert.AreEqual(TransactionStatus.Failed, currTransaction.Status);
        }

        [Test]
        public void ChangeTransactionStatusMethodShouldThrowExceptionWhenTransactionDoesntExist()
        {
            Assert.Throws<ArgumentException>(() => 
            chainblock.ChangeTransactionStatus(123, TransactionStatus.Failed));
        }

        [Test]
        public void RemoveTransactionMethodShouldRemoveTransactionsCorrectly()
        {
            chainblock.Add(new Transaction(123, TransactionStatus.Successfull, "Asen", "Gosho", 50));

            chainblock.RemoveTransactionById(123);

            Assert.AreEqual(0, chainblock.Count);
            Assert.IsFalse(chainblock.Contains(123));
        }

        [Test]
        public void RemoveTransactionMethodShouldThrowExceptionIfTransactionDoesntExist()
        {
            chainblock.Add(new Transaction(12, TransactionStatus.Successfull, "Asen", "Gosho", 50));

            Assert.Throws<InvalidOperationException>(() => chainblock.RemoveTransactionById(123));
        }

        [Test]
        public void GetByIdMethodShouldReturnTransactionsCorrectly()
        {
            var transaction = new Transaction(15, TransactionStatus.Successfull, "Ivan", "Asen", 100);

            chainblock.Add(transaction);

            Assert.AreEqual(transaction, chainblock.GetById(15));
        }

        [Test]
        public void GetByIdMethodShouldThrowExceptionIfTransactionDoesntExist()
        {
            var transaction = new Transaction(15, TransactionStatus.Successfull, "Ivan", "Asen", 100);

            chainblock.Add(transaction);

            Assert.Throws<InvalidOperationException>(() => chainblock.GetById(12));
        }

        [Test]
        public void GetByTransactionStatusMethodShouldThrowExceptionIfTransactionsWithGivenStatusDoesntExist()
        {
            chainblock.Add(new Transaction(12, TransactionStatus.Aborted, "Ivan", "Asen", 50));
            chainblock.Add(new Transaction(13, TransactionStatus.Failed, "Ivan", "Asen", 50));
            chainblock.Add(new Transaction(14, TransactionStatus.Successfull, "Ivan", "Asen", 50));

            Assert.Throws<InvalidOperationException>(() => 
            chainblock.GetByTransactionStatus(TransactionStatus.Unauthorized));
        }

        [Test]
        public void GetByTransactionStatusMethodShouldReturnCorrectlyFilteredCollection()
        {
            var transactionStatus = TransactionStatus.Aborted;

            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0)
                {
                    transactionStatus = TransactionStatus.Failed;
                }
                else if (i % 3 == 0)
                {
                    transactionStatus = TransactionStatus.Successfull;
                }
                else if (i % 5 == 0)
                {
                    transactionStatus = TransactionStatus.Unauthorized;
                }

                var transaction = new Transaction(i, transactionStatus, "Sender", "Receiver", 50);

                chainblock.Add(transaction);
            }

            var expected = chainblock
                .Where(t => t.Status == TransactionStatus.Successfull)
                .OrderByDescending(t => t.Amount)
                .ToList();

            var actual = chainblock.GetByTransactionStatus(TransactionStatus.Successfull)
                .ToList();

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetAllSendersWithTransactionStatusMethodShouldReturnAllSendersCorrectly()
        {
            var transaction = new Transaction(1, TransactionStatus.Successfull, "Asen", "Ivan", 50);
            var transaction2 = new Transaction(2, TransactionStatus.Failed, "Gosho", "Pesho", 100);
            var transaction3 = new Transaction(3, TransactionStatus.Successfull, "Asen", "Ivan", 50);
            var transaction4 = new Transaction(4, TransactionStatus.Successfull, "Asen", "Ivan", 50);

            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);

            var expected = chainblock
                .Where(t => t.Status == TransactionStatus.Successfull)
                .OrderBy(t => t.Amount)
                .Select(t => t.From)
                .ToList();

            var actual = chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Successfull);

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetAllSendersWithTransactionStatusMethodShouldThrowExceptionIfNoTransactionExist()
        {
            var transaction = new Transaction(1, TransactionStatus.Successfull, "Asen", "Ivan", 50);
            var transaction2 = new Transaction(2, TransactionStatus.Failed, "Gosho", "Pesho", 100);
            var transaction3 = new Transaction(3, TransactionStatus.Successfull, "Asen", "Ivan", 50);
            var transaction4 = new Transaction(4, TransactionStatus.Successfull, "Asen", "Ivan", 50);

            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);

            Assert.Throws<InvalidOperationException>(() => 
            chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusMethodShouldReturnAllSendersCorrectly()
        {
            var transaction = new Transaction(1, TransactionStatus.Successfull, "Asen", "Ivan", 50);
            var transaction2 = new Transaction(2, TransactionStatus.Failed, "Gosho", "Pesho", 100);
            var transaction3 = new Transaction(3, TransactionStatus.Successfull, "Asen", "Ivan", 50);
            var transaction4 = new Transaction(4, TransactionStatus.Successfull, "Asen", "Ivan", 50);

            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);

            var expected = chainblock
                .Where(t => t.Status == TransactionStatus.Successfull)
                .OrderBy(t => t.Amount)
                .Select(t => t.To)
                .ToList();

            var actual = chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Successfull);

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetAllReceiversWithTransactionStatusMethodShouldThrowExceptionIfNoTransactionExist()
        {
            var transaction = new Transaction(1, TransactionStatus.Successfull, "Asen", "Ivan", 50);
            var transaction2 = new Transaction(2, TransactionStatus.Failed, "Gosho", "Pesho", 100);
            var transaction3 = new Transaction(3, TransactionStatus.Successfull, "Asen", "Ivan", 50);
            var transaction4 = new Transaction(4, TransactionStatus.Successfull, "Asen", "Ivan", 50);

            chainblock.Add(transaction);
            chainblock.Add(transaction2);
            chainblock.Add(transaction3);
            chainblock.Add(transaction4);

            Assert.Throws<InvalidOperationException>(() =>
            chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Aborted));
        }

        [Test]
        public void GetAllOrderedByAmountDescendingThenByIdMethodShouldSortAndReturnCollectionCorrectly()
        {
            chainblock.Add(new Transaction(123, TransactionStatus.Aborted, "Asen", "Ivan", 50));
            chainblock.Add(new Transaction(129, TransactionStatus.Aborted, "Ivan", "Asen", 100));
            chainblock.Add(new Transaction(127, TransactionStatus.Aborted, "Gosho", "Ivan", 500));
            chainblock.Add(new Transaction(126, TransactionStatus.Aborted, "Asen", "Petre", 450));

            var expected = this.chainblock
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();

            var actual = this.chainblock.GetAllOrderedByAmountDescendingThenById();

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetBySenderOrderedByAmountDescendingMethodShouldReturnAllTransactionBySenderCorrectlySorted()
        {
            chainblock.Add(new Transaction(123, TransactionStatus.Aborted, "Asen", "Ivan", 50));
            chainblock.Add(new Transaction(129, TransactionStatus.Aborted, "Ivan", "Asen", 100));
            chainblock.Add(new Transaction(127, TransactionStatus.Aborted, "Gosho", "Ivan", 500));
            chainblock.Add(new Transaction(126, TransactionStatus.Aborted, "Asen", "Petre", 450));

            var expected = this.chainblock
                .Where(t => t.From == "Asen")
                .OrderByDescending(t => t.Amount)
                .ToList();

            var actual = this.chainblock.GetBySenderOrderedByAmountDescending("Asen");

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetBySenderOrderByAmountDescendingMethodShouldThrowExceptionIfSenderDoesntExist()
        {
            chainblock.Add(new Transaction(123, TransactionStatus.Aborted, "Asen", "Ivan", 50));
            chainblock.Add(new Transaction(129, TransactionStatus.Aborted, "Ivan", "Asen", 100));

            Assert.Throws<InvalidOperationException>(() => this.chainblock
            .GetBySenderOrderedByAmountDescending("Lelq ti Goshka"));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdMethodShouldReturnCorrecltySortedCollection()
        {
            chainblock.Add(new Transaction(123, TransactionStatus.Aborted, "Asen", "Ivan", 50));
            chainblock.Add(new Transaction(129, TransactionStatus.Aborted, "Ivan", "Asen", 100));
            chainblock.Add(new Transaction(123, TransactionStatus.Aborted, "Asen", "Ivan", 50));

            var expected = this.chainblock
                .Where(t => t.To == "Ivan")
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();

            var actual = this.chainblock.GetByReceiverOrderedByAmountThenById("Ivan");

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetByReceiverOrderedByAmountThenByIdMethodShouldThrowExceptionIfThereAreNotTransactions()
        {
            chainblock.Add(new Transaction(123, TransactionStatus.Aborted, "Asen", "Ivan", 50));
            chainblock.Add(new Transaction(129, TransactionStatus.Aborted, "Ivan", "Asen", 100));

            Assert.Throws<InvalidOperationException>(() => this.chainblock
            .GetByReceiverOrderedByAmountThenById("Gosho"));
        }

        [Test]
        [TestCase(TransactionStatus.Successfull, 100)]
        [TestCase(TransactionStatus.Failed, 50)]
        public void GetByTransactionStatusAndMaximumAmountMethodShouldReturnCollectionCorreclty(
            TransactionStatus status, double maximumAmount)
        {
            var expected = this.chainblock
                .Where(t => t.Status == status && t.Amount <= maximumAmount)
                .ToList();

            var actual = this.chainblock.GetByTransactionStatusAndMaximumAmount(status, maximumAmount);

            Assert.That(expected, Is.EqualTo(actual));
        }

        [Test]
        [TestCase("Asen", 50)]
        public void GetBySenderAndMinimumAmountDescendingMethodShouldReturnSortedCollectionCorreclty(
            string sender, double amount)
        {
            chainblock.Add(new Transaction(123, TransactionStatus.Aborted, "Asen", "Ivan", 50));
            chainblock.Add(new Transaction(129, TransactionStatus.Aborted, "Ivan", "Asen", 100));
            chainblock.Add(new Transaction(124, TransactionStatus.Aborted, "Asen", "Ivan", 150));

            var expected = this.chainblock
                .Where(t => t.From == sender && t.Amount > amount)
                .ToList();

            var actual = this.chainblock.GetBySenderAndMinimumAmountDescending(sender, amount);
        }

        [Test]
        public void GetBySenderAndMinimumAmountDescendingMethodShouldThrowExceptionIfCollectionIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock
            .GetBySenderAndMinimumAmountDescending("Lelq ti Goshka", 500));
        }

        [Test]
        [TestCase("Ivan", 40, 200)]
        public void GetByReceiverAndAmountRangeMethodShouldReturnSortedCollectionCorreclty(
            string receiver,
            double lo,
            double hi)
        {
            chainblock.Add(new Transaction(123, TransactionStatus.Aborted, "Asen", "Ivan", 50));
            chainblock.Add(new Transaction(129, TransactionStatus.Aborted, "Ivan", "Asen", 100));
            chainblock.Add(new Transaction(124, TransactionStatus.Aborted, "Asen", "Ivan", 150));

            var expected = this.chainblock
                .Where(t => t.To == receiver && t.Amount >= lo && t.Amount < hi)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();

            var actual = this.chainblock.GetByReceiverAndAmountRange(receiver, lo, hi);

            Assert.That(expected, Is.EquivalentTo(actual));
        }

        [Test]
        public void GetByReceiverAndAmountRangeMethodShouldThrowExceptionIfCollectionIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => this.chainblock
            .GetByReceiverAndAmountRange("Lelq ti Goshka", 50, 100));
        }

        [Test]
        [TestCase(40, 200)]
        [TestCase(200, 400)]
        public void GetAllInAmountRangeMethodShouldReturnCollectionCorrectly(double lo, double hi)
        {
            chainblock.Add(new Transaction(123, TransactionStatus.Aborted, "Asen", "Ivan", 50));
            chainblock.Add(new Transaction(129, TransactionStatus.Aborted, "Ivan", "Asen", 100));
            chainblock.Add(new Transaction(124, TransactionStatus.Aborted, "Asen", "Ivan", 150));

            var expected = this.chainblock
                .Where(t => t.Amount >= lo && t.Amount <= hi)
                .ToList();

            var actual = this.chainblock.GetAllInAmountRange(lo, hi);

            Assert.That(expected, Is.EquivalentTo(actual));
        }
    }
}
