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

        public static async Task<PersonDbModel> GetPersonDataById(int id)
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
    }

    public class SpaceshipDbModel
    {
        [Key]
        public int SpaceshipDbModelId { get; private set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public double Length { get; set; }

        //Relationships
        public int? PersonDbModelId { get; set; }
        [ForeignKey("PersonDbModelId")]
        public PersonDbModel PersonDbModel { get; set; }

        public ParkingSpaceDbModel ParkingSpaceDbModel { get; set; }

        //Methods
        public static SpaceshipDbModel CreateModelFromAPI(ApiDataFetch dataFetch, int searchIndex)
        {
            SpaceshipData spaceshipData = dataFetch.GetSpaceShip(searchIndex);
            return new SpaceshipDbModel
            {
                Name = spaceshipData.name,
                Length = double.Parse(spaceshipData.length),
            };
        }

        public static async Task<SpaceshipDbModel> CreateModelFromDb(int id)
        {
            SpaceshipDbModel spaceShip = null;

            using (var context = new SpaceParkContext())
            {
                Console.WriteLine("Start GetSpaceship...");

                spaceShip = await context.SpaceshipInfo.Where(s => s.SpaceshipDbModelId == id).FirstOrDefaultAsync<SpaceshipDbModel>();

                Console.WriteLine("Finished GetSpaceship...");
            }

            return spaceShip;
        }
    }

    public class ParkingSpaceDbModel
    {
        [Key]
        public int ParkingSpaceDbModelId { get; private set; }

        //Relationships
        public int? SpaceshipDbModelId { get; set; }
        [ForeignKey("SpaceshipDbModelId")]
        public SpaceshipDbModel SpaceshipDbModel { get; set; }

        //Methods
        public static async Task<ParkingSpaceDbModel> CreateModelFromDb(int id)
        {
            ParkingSpaceDbModel parkingSpace = null;

            using (var context = new SpaceParkContext())
            {
                Console.WriteLine("Start GetSpaceship...");

                parkingSpace = await context.ParkingSpaceInfo.Where(s => s.ParkingSpaceDbModelId == id).FirstOrDefaultAsync<ParkingSpaceDbModel>();

                Console.WriteLine("Finished GetSpaceship...");
            }

            return parkingSpace;
        }
    }
}
