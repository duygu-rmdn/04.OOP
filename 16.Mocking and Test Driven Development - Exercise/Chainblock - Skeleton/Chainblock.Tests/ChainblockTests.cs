using Chainblock.Contracts;
using Chainblock.Models;
using NUnit.Framework;

namespace Chainblock.Tests
{
    [TestFixture]
    class ChainblockTests
    {
        

        [Test]
        [Category("Add method")]
        public void
            GivenTransaction_WhenAddTransactionIsCalled_ThenTransactionCountIncrease()
        {
            ITransaction transaction = new Transaction()
            {
                Id = 1,
                From = "Duygu",
                To = "Pesho",
                Status = TransactionStatus.Successfull,
                Amount = 5
            };
            IChainblock chainblock = new Chainblock();

            chainblock.Add(transaction);

            Assert.AreEqual(1, chainblock.Count);
        }
    }
}
