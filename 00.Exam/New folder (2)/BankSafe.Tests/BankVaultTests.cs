using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
            BankVault bav = new BankVault();
        }

        [Test]
        public void test1()
        {
            Item bank = new Item("ed", "asd");
            Assert.AreEqual(bank.Owner, "ed");
            Assert.AreEqual(bank.ItemId, "asd");
        }
        [Test]
        public void test2()
        {
            Item bank = new Item("ed", "asd");
            BankVault bav = new BankVault();
            

            Assert.Throws<ArgumentException>(() => bav.AddItem("sbhd", bank));
        }
        [Test]
        public void test3()
        {
            Item bank = new Item("ed", "asd");
            Item bank1 = new Item("ed", "asd");
            BankVault bav = new BankVault();


            Assert.Throws<ArgumentException>(() => bav.AddItem("sbhd", bank));
        }
        //$"Item:{item.ItemId} saved successfully!"
        [Test]
        public void test4()
        {
            Item bank = new Item("ed", "asd");
            Item bank1 = new Item("ed", "asd");
            BankVault bav = new BankVault();
            string sdds = $"Item:{bank} saved successfully!";

            Assert.Throws<ArgumentException>(() => bav.AddItem("sbhd", bank));
        }
        
        [Test]
        public void test6()
        {
            Item bank = new Item("A1", "asd");
            BankVault bav = new BankVault();

            Assert.Throws<ArgumentException>(() => bav.AddItem("sadssa", bank));
        }
        [Test]
        public void test7()
        {
            Item bank = new Item("A1", "asd");
            Item bank2 = new Item("wefrweef", "asd");
            BankVault bav = new BankVault();
            BankVault bav1 = new BankVault();
            bav1.AddItem("A1", bank2);
            Assert.Throws<ArgumentException>(() => bav.RemoveItem("A1", bank2));
        }
        [Test]
        public void test8()
        {
            Item bank = new Item("A1", "asd");
            Item bank2 = new Item("wefrweef", "asd");
            BankVault bav = new BankVault();
            BankVault bav1 = new BankVault();
            bav1.AddItem("A1", bank2);
            Assert.Throws<ArgumentException>(() => bav.RemoveItem("A1", bank));
        }
        //$"Remove item:{item.ItemId} successfully!";
        [Test]
        public void test5()
        {
            Item bank = new Item("A1", "asd");
            BankVault bav = new BankVault();

            Assert.Throws<ArgumentException>(() => bav.AddItem("ıÍ‡ˆ‰ıÍˆÊ", bank));
        }
        [Test]
        public void test123()
        {
            Item bank = new Item("A1", "asd");
            BankVault bav = new BankVault();
            bav.AddItem("A1", bank);
            Assert.Throws<ArgumentException>(() => bav.AddItem("A1", bank));
        }
        [Test]
        public void test122()
        {
            Item bank = new Item("A1", "asd");
            BankVault bav = new BankVault();
            bav.AddItem("A1", bank);
            Assert.Throws<ArgumentException>(() => bav.RemoveItem("shakasjas", bank));
        }
        [Test]
        public void test1asd2()
        {
            Item bank = new Item("A1", "asd");
            Item bank2 = new Item("asd", "asasd");
            BankVault bav = new BankVault();
            bav.AddItem("A1", bank);
            Assert.Throws<ArgumentException>(() => bav.RemoveItem("A1", bank2));
        }
        
    }
}