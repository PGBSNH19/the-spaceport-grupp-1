using SpacePort;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class SpaceParkCorp
    {
        private IBankAccountComponent bankAccount;
        private ParkingService parkingService;

        public SpaceParkCorp(IBankAccountComponent bankAccount, ParkingService parkingService)
        {
            this.bankAccount = bankAccount;
            this.parkingService = parkingService;
        }

        public bool CheckIn(Person person, Spaceship spaceship)
        {
            bool isAllowed = parkingService.IsAllowedToPark(person, spaceship) && parkingService.FreeParkingSpace();
            if (isAllowed)
            {
                parkingService.ParkSpaceship(person, spaceship);
            }
            return isAllowed;
        }

        public bool CheckOut(Person person, Spaceship spaceship)
        {
            parkingService.CreateInvoice()
        }

        

        //Bank account methods
        public void Deposit(double amount)
        {
            if (ValidateCustomer(amount))
            {
                bankAccount.Deposit(amount);
            }
        }

        public void Withdraw(double amount)
        {
            bankAccount.Withdraw(amount);
        }

        public double CheckBalance()
        {
            return bankAccount.CheckBalance();
        }

        //Parking control methods


        public bool NumberOfFreeParkingSpaces()
        {

            return parkingService.FreeParkingSpace();
        }

        public bool ValidateCustomer(double amount)
        {
            return amount >= 100;
        }
    }
}
