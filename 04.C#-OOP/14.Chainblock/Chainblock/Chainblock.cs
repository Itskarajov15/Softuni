using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> transactions;

        public Chainblock()
        {
            this.transactions = new Dictionary<int, ITransaction>();
        }

        public int Count => this.transactions.Count;

        public void Add(ITransaction tx)
        {
            if (!this.Contains(tx.Id))
            {
                this.transactions.Add(tx.Id, tx);
            }
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.Contains(id))
            {
                throw new ArgumentException();
            }
            var currTransaction = this.transactions[id];

            currTransaction.Status = newStatus;
        }

        public bool Contains(ITransaction tx)
            => this.transactions.ContainsKey(tx.Id);

        public bool Contains(int id)
            => this.transactions.ContainsKey(id);

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            return this.transactions
                .Values
                .Where(t => t.Amount >= lo && t.Amount <= hi)
                .ToList();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactions
                .Values
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            var receivers = this.transactions
                .Values
                .Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.To)
                .ToList();

            if (receivers.Count <= 0)
            {
                throw new InvalidOperationException();
            }

            return receivers;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            var senders = this.transactions
                .Values
                .Where(t => t.Status == status)
                .OrderBy(t => t.Amount)
                .Select(t => t.From)
                .ToList();

            if (senders.Count <= 0)
            {
                throw new InvalidOperationException();
            }

            return senders;
        }

        public ITransaction GetById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException();
            }

            return this.transactions[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            var sortedTransactions = this.transactions
                .Values
                .Where(t => t.To == receiver && t.Amount >= lo && t.Amount < hi)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();

            if (sortedTransactions.Count <= 0)
            {
                throw new InvalidOperationException();
            }

            return sortedTransactions;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            var transactionToReceiver = this.transactions
                .Values
                .Where(t => t.To == receiver)
                .OrderByDescending(t => t.Amount)
                .ThenBy(t => t.Id)
                .ToList();

            if (transactionToReceiver.Count <= 0)
            {
                throw new InvalidOperationException();
            }

            return transactionToReceiver;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            var transactionsBySender = this.transactions
                .Values
                .Where(t => t.From == sender && t.Amount > amount)
                .ToList();

            if (transactionsBySender.Count <= 0)
            {
                throw new InvalidOperationException();
            }

            return transactionsBySender;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            var transactionsBySender = this.transactions
                .Values
                .Where(t => t.From == sender)
                .OrderByDescending(t => t.Amount)
                .ToList();

            if (transactionsBySender.Count <= 0)
            {
                throw new InvalidOperationException();
            }

            return transactionsBySender;
        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            if (!this.transactions.Any(t => t.Value.Status == status))
            {
                throw new InvalidOperationException();
            }

            List<ITransaction> result = this.transactions
                .Values
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount)
                .ToList();

            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            return this.transactions
                .Values
                .Where(t => t.Status == status && t.Amount <= amount)
                .ToList();
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var transaction in this.transactions)
            {
                yield return transaction.Value;
            }
        }

        public void RemoveTransactionById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException();
            }

            this.transactions.Remove(id);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
