using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort 
{
    public class CompanyBankAccount : BankAccountComponent
    {
        private IEventLogComponent bankAccountLog = new EventLogComponent();
        
        public CompanyBankAccount(double amount = 0) : base(amount) { }

        public override void Deposit(double amount)
        {
            if (amount > 0)
            {
                base.Deposit(amount);
                bankAccountLog.WriteToEventLog($"Deposit: {amount}.");
            }
            else
            {
                bankAccountLog.WriteToEventLog($"Deposit: Invalid amount ({amount}). No deposit.");
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
