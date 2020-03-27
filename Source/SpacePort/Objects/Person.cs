using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePort
{
    public class Person
    {
        public int ID { get; private set; }
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
        }/// <summary>
         /// Converts this type to a type that represents it's database model structure.
         /// </summary>
         /// <returns></returns>
        public PersonDbModel ToDbModel()
        {
            return new PersonDbModel
            {
                Name = this.Name,
                Wallet = this.Wallet
            };
        }

        public static async Task<List<Person>> GetSpaceShipsAsync()
        {
            SpaceParkContext context = new SpaceParkContext();
            List<Person> persons = new List<Person>();
            var ids = context.PersonInfo.Select(s => s.PersonDbModelId).ToList();
            for (int i = 0; i < ids.Count; i++)
            {
                PersonDbModel model = await PersonDbModel.CreateModelFromDb(ids[i]);
                Person person = model.CreateObjectFromModel();
                persons.Add(person);
            }
            return persons;

        }
    }
}
