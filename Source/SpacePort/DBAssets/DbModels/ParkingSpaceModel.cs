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
    public class ParkingSpaceModel
    {
        [Key]
        public int ParkingSpaceID { get; private set; }

        //Relationships
        public int? SpaceshipID { get; set; }
        [ForeignKey("SpaceshipID")]
        public SpaceshipModel Spaceship { get; set; }

        //Methods
        public static async Task<ParkingSpaceModel> CreateModelFromDb(int id)
        {
            ParkingSpaceModel parkingSpace = null;

            using (var context = new SpaceParkContext())
            {
                parkingSpace = await context.Parkingspace.FindAsync(id);
                if (parkingSpace.SpaceshipID.HasValue)
                {
                    parkingSpace.Spaceship = SpaceshipModel.CreateModelFromDb(parkingSpace.SpaceshipID.Value).Result;
                }
            }

            return parkingSpace;
        }

        public ParkingSpace CreateObjectFromModel()
        {
            ParkingSpace temp = new ParkingSpace();
            temp.SetID(this.ParkingSpaceID);

            if (this.Spaceship != null)
            {
                temp.OccupyingSpaceship = this.Spaceship.CreateObjectFromModel();
            }

            return temp;            
        }
    }
}
