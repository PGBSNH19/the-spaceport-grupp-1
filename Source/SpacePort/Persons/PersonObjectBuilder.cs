using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{    public interface IAddFeatures
    {
        IAddFeatures AddWallet(double wallet);
        Person BuildPerson();
    }

    public class PersonObjectBuilder : IAddFeatures
    {
        private string name;
        private double wallet;

        public PersonObjectBuilder(string name)
        {
            this.name = name;
        }

        public static Person BuildFromApi(int id)
        {
            ApiDataFetch data = new ApiDataFetch();
            var PersonData = data.GetPerson(id);

            return PersonObjectBuilder
                .AddName(PersonData.name)
                .AddWallet(200.5)
                .BuildPerson();
        }

        public static IAddFeatures AddName(string name) => new PersonObjectBuilder(name);

        public IAddFeatures AddWallet(double wallet)
        {
            this.wallet = wallet;
            return this;
        }
        
        public Person BuildPerson()
        {
            return new Person(this.name, this.wallet);
        }        
    }
}
