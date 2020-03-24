using SpacePort.API;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class SpaceParkCorp
    {
        private IAccountComponent CashRegister = new CompanyAccount();
        private TicketBooth TBooth;


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


        public bool IsAllowedToPark(Character person, SpaceshipInformation spaceship)
        {

            return TBooth.IsAllowedToPark(person, spaceship);
        }
        public int NumberOfFreeParkingSpaces()
        {
            
            return TBooth.NumberOfFreeParkingSpaces();
        }




    }
}
