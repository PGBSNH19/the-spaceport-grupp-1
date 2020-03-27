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
    public class PersonDbModel
    {
        [Key]
        public int PersonDbModelId { get; private set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public double Wallet { get; set; }

        //Relationships
        public SpaceshipDbModel SpaceshipDbModel { get; set; }

        //Methods
        public PersonDbModel CreateModelFromAPI(ApiDataFetch dataFetch, int searchIndex)
        {
            PersonData personData = dataFetch.GetPerson(searchIndex);
            return new PersonDbModel
            {
                Name = personData.name,
                Wallet = 300
            };
        }

        public static async Task<PersonDbModel> CreateModelFromDb(int id)
        {
            PersonDbModel person = null;

            using (var context = new SpaceParkContext())
            {
                Console.WriteLine("Start GetPerson...");

                person = await context.PersonInfo.Where(s => s.PersonDbModelId == id).FirstOrDefaultAsync<PersonDbModel>();

                Console.WriteLine("Finished GetPerson...");
            }

            return person;
        }

        public Person CreateObjectFromModel()
        {
            return new Person(this.PersonDbModelId, this.Name, this.Wallet);
        }
    }
}
