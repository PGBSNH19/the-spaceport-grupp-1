using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SpacePort
{
    public class PersonModel
    {
        [Key]
        public int PersonID { get; private set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public double Wallet { get; set; }

        //Relationships
        public SpaceshipModel Spaceship { get; set; }

        //Methods
        public PersonModel CreateModelFromAPI(ApiDataFetch dataFetch, int searchIndex)
        {
            PersonData personData = dataFetch.GetPerson(searchIndex);
            return new PersonModel
            {
                Name = personData.name,
                Wallet = 300
            };
        }

        public static async Task<PersonModel> CreateModelFromDb(int id)
        {
            PersonModel person = null;

            using (var context = new SpaceParkContext())
            {
                person = await context.Person.Where(s => s.PersonID == id).FirstOrDefaultAsync<PersonModel>();
            }

            return person;
        }

        public Person CreateObjectFromModel()
        {
            return new Person(this.PersonID, this.Name, this.Wallet);
        }
    }
}
