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
        private InvoiceModel invoice;
        private bool isCheckedIn;
        private bool hasPayed;

        public SpaceParkCorp(IBankAccountComponent bankAccount, ParkingService parkingService)
        {
            this.bankAccount = bankAccount;
            this.parkingService = parkingService;
            this.isCheckedIn = false;
            this.hasPayed = false;
        }

        public bool CheckIn(Person person, Spaceship spaceship, List<string> eventLog)
        {
            bool isAllowed = parkingService.AllowedPerson(person);
            eventLog.Add(isAllowed ? "Person check...OK" : "Person check made and you not allowed to park here, sorry!");
            if (!isAllowed)
            {
                return isAllowed;
            }

            isAllowed = parkingService.AllowedShipLength(spaceship);
            eventLog.Add(isAllowed ? "Spaceshiplength is..OK" : "Spaceshiplength is not allowed");
            if (!isAllowed)
            {
                return isAllowed;
            }

            isAllowed = parkingService.FreeParkingSpace();
            eventLog.Add(isAllowed ? "Free parkingspace found" : "Free parkingspace found, sorry!");
            this.isCheckedIn = isAllowed;
            return isAllowed;
        }

        public bool ValidateCustomerPayment(Person person, Spaceship spaceship, List<string> eventLog)
        {
            if (person.Wallet >= 100 && isCheckedIn)
            {
                eventLog.Add(person.Wallet >= 100 ? "Person have enough money" : "Person dont have enough money");
                Deposit(100);
                person.Wallet -= 100;
                Spaceship.AddSpaceShipToDb(spaceship, person);
                parkingService.ParkSpaceship(person, spaceship);
                this.hasPayed = true;
            }
            else
            {
                eventLog.Add(isCheckedIn ? "" : "You have not checked in yet");
            }
            
            return person.Wallet >= 100 && isCheckedIn;
        }

        public bool CheckOut(Spaceship spaceship, List<string> eventLog)
        {
            if (isCheckedIn && hasPayed)
            {
                return parkingService.DepartSpaceShip(spaceship);

            }
            eventLog.Add(isCheckedIn ? "" : "You have not checked in yet");
            eventLog.Add(hasPayed ? "" : "You have not payed yet");
            return isCheckedIn && hasPayed;
        }



        //Bank account methods
        public void Deposit(double amount)
        {
            bankAccount.Deposit(amount);
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


        public bool FreeParkingSpace()
        {

            return parkingService.FreeParkingSpace();
        }

    }
}
