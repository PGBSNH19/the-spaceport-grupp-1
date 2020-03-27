//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SpacePort
//{
//    public class ParkingSpaceModel
//    {
//        [Key]
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public int ParkingSpaceID { get; set; }
//        public bool Occupied { get; set; }
//        public SpaceShipModel SpaceShip { get; set; }
//        public static async Task<ParkingSpaceModel> CreateModelFromDb(int id)
//        {
//            ParkingSpaceModel parkingSpace = null;

//            using (var context = new SpaceParkContext())
//            {
//                Console.WriteLine("Start GetSpaceship...");

//                parkingSpace = await context.ParkingSpace.Where(s => s.ParkingSpaceID == id).FirstOrDefaultAsync<ParkingSpaceModel>();

//                Console.WriteLine("Finished GetSpaceship...");
//            }

//            return parkingSpace;
//        }
//    }
//}
