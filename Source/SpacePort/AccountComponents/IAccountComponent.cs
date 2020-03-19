using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public interface IAccountComponent
    {
        double Withdraw(double amount);
        void Deposit(double amount);
        double CheckBalance();
    }
}
