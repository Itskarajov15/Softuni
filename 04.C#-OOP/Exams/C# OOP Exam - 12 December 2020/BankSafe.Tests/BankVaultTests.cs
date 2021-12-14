using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault vault;
        private Item item;

        [SetUp]
        public void Setup()
        {
            this.vault = new BankVault();
            this.item = new Item("Asen", "123");

            this.vault.AddItem("A1", this.item);
        }

        [Test]
        public void AddItemMethodShouldThrowExceptionIfCellDoesntExist()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => vault.AddItem("asd", this.item));

            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }

        [Test]
        public void AddItemMethodShouldThrowExceptionIfCellIsAlreadyTaken()
        {
            var newItem = new Item("Gosho", "12");

            var ex = Assert.Throws<ArgumentException>(() => vault.AddItem("A1", newItem));

            Assert.AreEqual(ex.Message, "Cell is already taken!");
        }

        [Test]
        public void AddItemMethodShouldThrowExceptionIfItemAlreadyExist()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => vault.AddItem("A2", this.item));

            Assert.AreEqual(ex.Message, "Item is already in cell!");
        }

        [Test]
        public void AddItemMethodShouldAddItemCorrectly()
        {
            var item2 = new Item("Lelq ti Goshka", "1");

            this.vault.AddItem("B3", item2);

            Assert.AreEqual(item2, vault.VaultCells["B3"]);
        }

        [Test]
        public void AddItemMethodShouldReturnCorrectMessage()
        {
            var item2 = new Item("Lelq ti Goshka", "1");

            string result = this.vault.AddItem("B3", item2);

            Assert.AreEqual(result, $"Item:{item2.ItemId} saved successfully!");
        }

        [Test]
        public void RemoveItemMethodShouldThrowExceptionIfCellDoesntExist()
        {
            Exception ex = Assert.Throws<ArgumentException>(() => vault.RemoveItem("asd", this.item));

            Assert.AreEqual(ex.Message, "Cell doesn't exists!");
        }

        [Test]
        public void RemoveItemMethodShouldThrowExceptionIfItemInTheCellDoesntExist()
        {
            var ex = Assert.Throws<ArgumentException>(() => vault.RemoveItem("B1", item));

            Assert.AreEqual(ex.Message, "Item in that cell doesn't exists!");
        }

        [Test]
        public void RemoveItemMethodShouldRemoveItemsCorrectly()
        {
            var result = this.vault.RemoveItem("A1", item);

            Assert.AreEqual(null, this.vault.VaultCells["A1"]);
        }

        [Test]
        public void RemoveItemMethodShouldReturnCorrectMessage()
        {
            var result = this.vault.RemoveItem("A1", item);

            Assert.AreEqual(result, $"Remove item:{item.ItemId} successfully!");
        }
    }
}