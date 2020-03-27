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
                Console.WriteLine("Start GetSpaceship...");

                parkingSpace = await context.ParkingSpaceInfo.Where(s => s.ParkingSpaceDbModelId == id).FirstOrDefaultAsync<ParkingSpaceDbModel>();

                Console.WriteLine("Finished GetSpaceship...");
            }

            return parkingSpace;
        }

        public ParkingSpace CreateObjectFromModel()
        {
            if (this.SpaceshipDbModel != null)
            {
                ParkingSpace temp = new ParkingSpace();


                return new ParkingSpace 
                { 
                    OccupyingSpaceship = this.SpaceshipDbModel.CreateObjectFromModel()
                };
            }

            return new ParkingSpace();            
        }
    }
}
