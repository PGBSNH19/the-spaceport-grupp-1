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
            if(balance > 0)
            {
            this.balance = balance;

            }
            else
            {
                this.balance = 0;
            }
        }

        public virtual double Withdraw(double amount)
        {
            if (amount > 0 && balance - amount >= 0)
            {
                balance -= amount;
                return amount;
            }
            return 0;
        }

        public virtual void Deposit(double amount)
        {
            if (amount>0)
            {
                balance +=amount;
            }

            
        }

        public virtual double CheckBalance()
        {
            return balance;
        }
    }
}
