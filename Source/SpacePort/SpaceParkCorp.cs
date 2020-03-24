using SpacePort;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class SpaceParkCorp
    {
        private IAccountComponent CashRegister = new CompanyAccount();
        private TicketBooth ticketBooth;


        public int Fee()
        {
            return 0;
        }

        public void CheckOut()
        {

        }

        public void Deposit(double amount) 
        {
            CashRegister.Deposit(amount);
        }

        public void Withdraw(double amount)
        {
            CashRegister.Withdraw(amount);
        }

        public double CheckBalance()
        {
            return CashRegister.CheckBalance();
        }


        public bool IsAllowedToPark(Person person, SpaceshipData spaceship)
        {

            return true;
        }
        public int NumberOfFreeParkingSpaces()
        {
            
            return ticketBooth.NumberOfFreeParkingSpaces();
        }




    }
}
