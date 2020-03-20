using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort 
{
    public class CompanyAccount : AccountComponent
    {
        private IEventLogComponent accountLog = new EventLogComponent();
        
        public CompanyAccount(double amount = 0) : base(amount) { }

        public override void Deposit(double amount)
        {
            if (amount > 0)
            {
                base.Deposit(amount);
                accountLog.WriteToLog($"Deposit: {amount}.");
            }
            else
            {
                accountLog.WriteToLog($"Deposit: Invalid amount ({amount}). No deposit.");
            }
        }

        public override double Withdraw(double amount)
        {
            return base.Withdraw(amount);
        }

        public override double CheckBalance()
        {
            return base.CheckBalance();
        }
    }
}
