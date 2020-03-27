//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SpacePort.Dep
//{
//    public class SpaceShipModel
//    {
//        [Key]
//        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//        public int SpaceShipID { get; private set; }
//        public string Name { get; set; }
//        public double Length { get; set; }
//        public PersonModel Owner { get; set; }

//        public static SpaceShipModel CreateModelFromAPI(ApiDataFetch dataFetch, int searchIndex, PersonModel owner)
//        {
//            SpaceshipData spaceshipData = dataFetch.GetSpaceShip(searchIndex);
//            return new SpaceShipModel
//            {
//                Name = spaceshipData.name,
//                Length = double.Parse(spaceshipData.length),
//                Owner = owner
//            };
//        }

//        public static async Task<SpaceShipModel> CreateModelFromDb(int id)
//        {
//            SpaceShipModel spaceShip = null;

//            using (var context = new SpaceParkContext())
//            {
//                Console.WriteLine("Start GetSpaceship...");

//                spaceShip = await context.SpaceShip.Where(s => s.SpaceShipID == id).FirstOrDefaultAsync<SpaceShipModel>();

//                Console.WriteLine("Finished GetSpaceship...");
//            }

//            return spaceShip;
//        }
//    }
//}
