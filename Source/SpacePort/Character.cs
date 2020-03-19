using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class Character
    {
        public string Name { get; set; }
        //Ska egentligen ett skepp ha en passagerare som är karaktären?
        public int SpaceShipID { get; set; }

        private readonly IAccountComponent wallet = new AccountComponent();

        public Character(string name, int spaceShipId, double wallet) {
            Name = name;
            this.wallet.Deposit(wallet);
            SpaceShipID = spaceShipId;
        }

        public double Pay(double amount)
        {
            return wallet.Withdraw(amount);
        }

        public void RecieveMoney(double amount)
        {
            wallet.Deposit(amount);
        }

        public double CheckWallet()
        {
            return wallet.CheckBalance();
        }
    }
}
