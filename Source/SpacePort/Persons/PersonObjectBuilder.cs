using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePort
{    public interface IAddFeatures
    {
        IAddFeatures AddID(int primaryKey);
        IAddFeatures AddWallet(double wallet);
        Person BuildPerson();
    }

    public class PersonObjectBuilder : IAddFeatures
    {
        private string name;
        private double wallet;
        private int personID;

        public static IAddFeatures AddName(string name) => new PersonObjectBuilder(name);

        public PersonObjectBuilder(string name)
        {
            this.name = name;
        }

        public IAddFeatures AddWallet(double wallet)
        {
            this.wallet = wallet;
            return this;
        }

        public IAddFeatures AddID(int primaryKey)
        {
            this.personID = primaryKey;
            return this;
        }

        public Person BuildPerson()
        {
            return new Person(this.personID, this.name, this.wallet);
        }

        public static Person BuildFromDataBase(int primaryKey)
        {
            PersonModel dbModel = GetPersonDataById(primaryKey).Result;

            return PersonObjectBuilder
                .AddName(dbModel.Name)
                .AddWallet(dbModel.Wallet)
                .AddID(dbModel.PersonID)
                .BuildPerson();
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

        public static async Task<PersonModel> GetPersonDataById(int id)
        {
            PersonModel person = null;

            using (var context = new SpaceParkContext())
            {
                Console.WriteLine("Start GetSpaceship...");

                person = await context.Person.Where(s => s.PersonID == id).FirstOrDefaultAsync<PersonModel>();

                Console.WriteLine("Finished GetSpaceship...");
            }

            return person;
        }
    }
}
