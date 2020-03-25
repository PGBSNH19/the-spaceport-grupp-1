using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public interface IBankAccountComponent
    {
        double Withdraw(double amount);
        void Deposit(double amount);
        double CheckBalance();
    }
}
