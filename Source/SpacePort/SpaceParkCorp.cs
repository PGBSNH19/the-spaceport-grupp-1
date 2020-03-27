//using SpacePort;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace SpacePort
//{
//    public class SpaceParkCorp
//    {
//        private IBankAccountComponent bankAccount;
//        private ParkingService parkingService;

//        public SpaceParkCorp(IBankAccountComponent bankAccount, ParkingService parkingService)
//        {
//            this.bankAccount = bankAccount;
//            this.parkingService = new ParkingService(19);
//        }

//        public void CheckOut()
//        {
//            throw new NotImplementedException();
//        }

//        //Bank account methods
//        public void Deposit(double amount) 
//        {
//            bankAccount.Deposit(amount);
//        }

//        public void Withdraw(double amount)
//        {
//            bankAccount.Withdraw(amount);
//        }

//        public double CheckBalance()
//        {
//            return bankAccount.CheckBalance();
//        }

//        //Parking control methods
//        public bool IsAllowedToPark(Person person, SpaceShip spaceship)
//        {

//            return parkingService.IsAllowedToPark(person, spaceship);
//        }

//        public int NumberOfFreeParkingSpaces()
//        {
            
//            return parkingService.NumberOfFreeParkingSpaces();
//        }
//    }
//}
