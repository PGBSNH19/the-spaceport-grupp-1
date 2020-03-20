using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpacePort;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort.Tests
{
    [TestClass()]
    public class AccountComponentTests
    {
        
        [TestMethod()]
        public void WithdrawTest()
        {
            double amount = 100;
            AccountComponent account = new AccountComponent(amount);
            account.Withdraw(-100);

            Assert.AreEqual(100, account.CheckBalance());
        }
    }
}