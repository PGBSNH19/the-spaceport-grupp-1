using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort 
{
    public class CompanyAccount : AccountComponent
    {
        private IEventLogger accountLog = new EventLogComponent();
        
        public CompanyAccount(double amount = 0) : base(amount) { }

        public override void Deposit(double amount)
        {
            if (amount < 1)
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
            if (CheckBalance() - amount < 0)
            {
                accountLog.WriteToLog($"Withdraw: Invalid amount ({amount}). Not enough funds.");
                return 0;
            }
            else
            {
                return base.Withdraw(amount);
            }        
        }
    }
}
