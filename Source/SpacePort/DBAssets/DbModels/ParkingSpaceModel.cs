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
                parkingSpace = await context.ParkingSpaceInfo.FindAsync(id);
                if (parkingSpace.SpaceshipDbModelId.HasValue)
                {
                    parkingSpace.SpaceshipDbModel = SpaceshipDbModel.CreateModelFromDb(parkingSpace.SpaceshipDbModelId.Value).Result;
                }
            }

            return parkingSpace;
        }

        public static async Task<ParkingSpaceDbModel> CreateModelFromDb(Person person, Spaceship spaceship)
        {
            ParkingSpaceDbModel parkingSpace = null;

            using (var context = new SpaceParkContext())
            {
                parkingSpace = await context.ParkingSpaceInfo.
                if (parkingSpace.SpaceshipDbModelId.HasValue)
                {
                    parkingSpace.SpaceshipDbModel = SpaceshipDbModel.CreateModelFromDb(parkingSpace.SpaceshipDbModelId.Value).Result;
                }
            }

            return parkingSpace;
        }

        public ParkingSpace CreateObjectFromModel()
        {
            ParkingSpace temp = new ParkingSpace();
            temp.SetID(this.ParkingSpaceDbModelId);

            if (this.SpaceshipDbModel != null)
            {
                temp.OccupyingSpaceship = this.SpaceshipDbModel.CreateObjectFromModel();
            }

            return temp;            
        }
    }
}
