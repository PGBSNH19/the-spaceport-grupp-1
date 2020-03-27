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

                spaceShip = await context.SpaceshipInfo.FindAsync(id);
                if (spaceShip.PersonDbModelId.HasValue)
                {
                    spaceShip.PersonDbModel = PersonDbModel.CreateModelFromDb(spaceShip.PersonDbModelId.Value).Result;
                }

                Console.WriteLine("Finished GetSpaceship...");
            }

            return spaceShip;
        }

        public Spaceship CreateObjectFromModel()
        {
            Spaceship temp;

            if (this.PersonDbModel != null)
            {
                temp = new Spaceship 
                { 
                    Name = this.Name, 
                    Length = this.Length, 
                    Owner = this.PersonDbModel.CreateObjectFromModel() 
                };
            }
            else
            {
                temp = new Spaceship
                {
                    Name = this.Name,
                    Length = this.Length
                };
            }
            temp.SetID(this.SpaceshipDbModelId);

            return temp;
        }
    }
}

