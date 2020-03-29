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
    public class SpaceshipModel
    {
        [Key]
        public int SpaceshipID { get; private set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public double Length { get; set; }

        //Relationships
        public int? PersonID { get; set; }
        [ForeignKey("PersonID")]
        public PersonModel Person { get; set; }

        public ParkingSpaceModel ParkingSpaceModel { get; set; }

        //Methods
        public static SpaceshipModel CreateModelFromAPI(ApiDataFetch dataFetch, int searchIndex)
        {
            SpaceshipData spaceshipData = dataFetch.GetSpaceShip(searchIndex);
            return new SpaceshipModel
            {
                Name = spaceshipData.name,
                Length = double.Parse(spaceshipData.length),
            };
        }

        public static async Task<SpaceshipModel> CreateModelFromDb(int id)
        {
            SpaceshipModel spaceShip = null;

            using (var context = new SpaceParkContext())
            {
                

                spaceShip = await context.Spaceship.FindAsync(id);
                if (spaceShip.PersonID.HasValue)
                {
                    spaceShip.Person = PersonModel.CreateModelFromDb(spaceShip.PersonID.Value).Result;
                }

               
            }

            return spaceShip;
        }

        public static async Task<SpaceshipModel> CreateModelFromDb(string name)
        {
            SpaceshipModel spaceShip = null;

            using (var context = new SpaceParkContext())
            {


                spaceShip = await context.Spaceship.FirstAsync(s => s.Person == null && s.Name == name);
                if (spaceShip.PersonID.HasValue)
                {
                    spaceShip.Person = PersonModel.CreateModelFromDb(spaceShip.PersonID.Value).Result;
                }
            }

            return spaceShip;
        }

        public Spaceship CreateObjectFromModel()
        {
            Spaceship temp;

            if (this.Person != null)
            {
                temp = new Spaceship 
                { 
                    Name = this.Name, 
                    Length = this.Length, 
                    Owner = this.Person.CreateObjectFromModel() 
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
            temp.SetID(this.SpaceshipID);

            return temp;
        }
    }
}

