using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePort
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Wallet { get; set; }

        public Person(string name, double wallet)
        {
            this.Name = name;
            this.Wallet = wallet;
        }

        public Person(int id, string name, double wallet)
        {
            this.ID = id;
            this.Name = name;
            this.Wallet = wallet;
        }

        /// <summary>
        /// Converts this type to a type that represents it's database model structure.
        /// </summary>
        /// <returns></returns>
        public PersonModel ToDbModel()
        {
            return new PersonModel
            {
                Name = this.Name,
                Wallet = this.Wallet
            };
        }

        public static Person CreateObjectFromAPI(ApiDataFetch dataFetch, int searchIndex)
        {
            PersonData personData = dataFetch.GetPerson(searchIndex);
            return new Person(personData.name, 200);
        }

        public static void AddPersonToDb(Person person)
        {
            using (var context = new SpaceParkContext())
            {
                context.Add(person.ToDbModel());
                context.SaveChanges();
            }
        }
        public static bool PersonExistInDb(Person person)
        {
            using (var context = new SpaceParkContext())
            {
                bool uniquePerson = context.Person.Where(p => p.Name == person.Name).FirstOrDefault() == null;
                return uniquePerson;
            }
        }

        public static void DeletePersonFromDb(Person person)
        {
            using (var context = new SpaceParkContext())
            {
                var p = context.Person.Single(a => a.Name == person.Name);
               
                context.Remove(p);
                context.SaveChanges();
            }
        }
    }
}

