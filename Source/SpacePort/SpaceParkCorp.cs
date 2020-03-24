using SpacePort;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class SpaceParkCorp
    {
        private IAccountComponent cashRegister;
        private TicketBooth ticketBooth;

        public SpaceParkCorp(IAccountComponent cashRegister, TicketBooth ticketBooth)
        {
            this.cashRegister = cashRegister;
            this.ticketBooth = new TicketBooth(19);
        }

        public int Fee()
        {
            return 0;
        }

        public void CheckOut()
        {

        }

        public void Deposit(double amount) 
        {
            cashRegister.Deposit(amount);
        }

        public void Withdraw(double amount)
        {
            cashRegister.Withdraw(amount);
        }

        public double CheckBalance()
        {
            return cashRegister.CheckBalance();
        }


        public bool IsAllowedToPark(Person person, SpaceShip spaceship)
        {

            return ticketBooth.IsAllowedToPark(person, spaceship);
        }
        public int NumberOfFreeParkingSpaces()
        {
            
            return ticketBooth.NumberOfFreeParkingSpaces();
        }




    }
}
