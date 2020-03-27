using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePort.Dep
{
    //public class PersonModel
    //{
    //    [Key]
    //    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    public int PersonID { get; private set; }

    //    public string Name { get; set; }

    //    public double Wallet { get; set; }

    //    public PersonModel CreateModelFromAPI(ApiDataFetch dataFetch, int searchIndex)
    //    {
    //        PersonData personData = dataFetch.GetPerson(searchIndex);
    //        return new PersonModel
    //        {
    //            Name = personData.name,
    //            Wallet = 300
    //        };
    //    }
    //    public static async Task<PersonModel> GetPersonDataById(int id)
    //    {
    //        PersonModel person = null;

    //        using (var context = new SpaceParkContext())
    //        {
    //            Console.WriteLine("Start GetPerson...");

    //            person = await context.Person.Where(s => s.PersonID == id).FirstOrDefaultAsync<PersonModel>();

    //            Console.WriteLine("Finished GetPerson...");
    //        }

    //        return person;
    //    }
    //}
}
