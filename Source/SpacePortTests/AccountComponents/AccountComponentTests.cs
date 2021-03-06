﻿//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using SpacePort;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace SpacePort.Tests
//{
//    [TestClass()]
//    public class AccountComponentTests
//    {

//        [TestMethod()]
//        public void WithdrawTest_WithdrawNegativeNumber_ReturnZero()
//        {
//            double amount = 100;
//            BankAccountComponent account = new BankAccountComponent(amount);
//            double result = account.Withdraw(-100);

//            Assert.AreEqual(0, result);
//        }

//        [TestMethod()]
//        public void WithdrawTest_WithdrawTooMuch_ReturnZero()
//        {
//            double amount = 100;
//            BankAccountComponent account = new BankAccountComponent(amount);
//            double result = account.Withdraw(1000);

//            Assert.AreEqual(0, result);
//        }

//        [TestMethod()]
//        public void WithdrawTest_WithdrawLessThanBalance_ReturnAmount()
//        {
//            double amount = 100;
//            BankAccountComponent account = new BankAccountComponent(amount);
//            double result = account.Withdraw(99);

//            Assert.AreEqual(99, result);
//        }

//        [TestMethod()]
//        public void WithdrawTest_WithdrawAll_ReturnAll()
//        {
//            double amount = 100;
//            BankAccountComponent account = new BankAccountComponent(amount);
//            double result = account.Withdraw(100);

//            Assert.AreEqual(100, result);
//            Assert.AreEqual(0, account.CheckBalance());
//        }

//        [TestMethod()]
//        public void DepositTest_DepositNegativeNumber_BalanceUnchange()
//        {
//            double depositAmount = -100;
//            double amount = 100;
//            BankAccountComponent account = new BankAccountComponent(amount);
//            account.Deposit(depositAmount);

//            Assert.AreEqual(amount, account.CheckBalance());

//        }

//        [TestMethod()]
//        public void DepositTest_DepositPositiveNumber_BalanceIncrease()
//        {
//            double depositAmount = 100;
//            double amount = 100;
//            BankAccountComponent account = new BankAccountComponent(amount);
//            account.Deposit(depositAmount);

//            Assert.AreEqual(amount + depositAmount, account.CheckBalance());

//        }

//        [TestMethod()]
//        public void CheckBalanceTest_ReturnBalance()
//        {
//            double amount = 100;
//            BankAccountComponent account = new BankAccountComponent(amount);

//            Assert.AreEqual(amount, account.CheckBalance());
//        }




//    }
//}