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

        public Spaceship CreateObjectFromModel()
        {
            if (this.PersonDbModel != null)
            {
                return new Spaceship 
                { 
                    Name = this.Name, 
                    Length = this.Length, 
                    Owner = this.PersonDbModel.CreateObjectFromModel() 
                };
            }

            return new Spaceship
            {
                Name = this.Name,
                Length = this.Length
            };
        }
    }
}

