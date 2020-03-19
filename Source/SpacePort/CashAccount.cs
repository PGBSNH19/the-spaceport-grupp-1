using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class AccountComponent : IAccountComponent
    {
        private double balance;

        public AccountComponent (double balance = 0)
        {
            this.balance = balance;
        }

        public virtual double Withdraw(double amount)
        {
            if (balance < amount)
            {
                return 0;
            }

            balance -= amount;
            return amount;
        }

        public virtual void Deposit(double amount)
        {
            balance += amount;
        }

        public virtual double CheckBalance()
        {
            return balance;
        }
    }

    public interface IAccountComponent
    {
        double Withdraw(double amount);
        void Deposit(double amount);
        double CheckBalance();
        
    }
}
