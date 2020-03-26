using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SpacePort
{
    public class PersonModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonID { get; private set; }

        public string Name { get; set; }

        public double Wallet { get; set; }

        public PersonModel CreateModelFromAPI(ApiDataFetch dataFetch, int searchIndex)
        {
            PersonData personData = dataFetch.GetPerson(searchIndex);
            return new PersonModel
            {
                Name = personData.name,
                Wallet = 300
            };
        }
    }
}
