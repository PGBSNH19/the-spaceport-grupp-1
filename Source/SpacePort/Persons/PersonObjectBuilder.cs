using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class PersonObjectBuilder : IAddFeatures
    {
        private string name;
        private double wallet;
        private int spaceShipID;

        public PersonObjectBuilder(string name)
        {
            this.name = name;
        }

        public static Person BuildFromApi(int id)
        {
            ApiFetchData data = new ApiFetchData();
            var PersonData = data.GetPerson(id);

            return PersonObjectBuilder
                .AddName(PersonData.name)
                .AddWallet(200.5)
                .AddSpaceShipID(1)
                .BuildPerson();
        }

        public static IAddFeatures AddName(string name) => new PersonObjectBuilder(name);

        public IAddFeatures AddWallet(double wallet)
        {
            this.wallet = wallet;
            return this;
        }
        public IAddFeatures AddSpaceShipID(int spaceShipID)
        {
            this.spaceShipID = spaceShipID;
            return this;
        }
        
        public Person BuildPerson()
        {
            return new Person(this.name, this.wallet, this.spaceShipID);
        }
        
    }

    public interface IAddFeatures
    {
        IAddFeatures AddWallet(double wallet);
        IAddFeatures AddSpaceShipID(int spaceShipID);
        Person BuildPerson();
    }
}
