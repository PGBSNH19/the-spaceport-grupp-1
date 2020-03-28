using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePort
{
    public class ParkingSpace
    {
        public int ParkingSpaceID { get; private set; }
        public Spaceship OccupyingSpaceship { get; set; }

        /// <summary>
        /// Warning: Set only when fetching from database!
        /// </summary>
        /// <param name="id"></param>
        public void SetID(int id)
        {
            this.ParkingSpaceID = id;
        }

        /// <summary>
        /// Converts this type to a type that represents it's database model structure.
        /// </summary>
        /// <returns></returns>
        public ParkingSpaceDbModel ToDbModel()
        {
            if (OccupyingSpaceship != null)
            {
                return new ParkingSpaceDbModel
                {
                    SpaceshipDbModel = this.OccupyingSpaceship.ToDbModel()
                };
            }

            return new ParkingSpaceDbModel();
        }
        public static async Task<List<ParkingSpace>> GetParkingSpaceAsync()
        {
            SpaceParkContext context = new SpaceParkContext();
            List<ParkingSpace> parkingSpaces = new List<ParkingSpace>();
            var ids = context.PersonInfo.Select(s => s.PersonDbModelId).ToList();
            for (int i = 0; i < ids.Count; i++)
            {
                ParkingSpaceDbModel model = await ParkingSpaceDbModel.CreateModelFromDb(ids[i]);
                ParkingSpace parkingspace = model.CreateObjectFromModel();
                parkingSpaces.Add(parkingspace);
            }
            return parkingSpaces;
        }

        public static async Task<ParkingSpace[]> GetParkingSpaceAsync(int count)
        {
            SpaceParkContext context = new SpaceParkContext();
            ParkingSpace[] parkingSpaces = new ParkingSpace[count];
            var ids = context.ParkingSpaceInfo.Select(s => s.ParkingSpaceDbModelId).ToList();
            for (int i = 0; i < ids.Count && i < count; i++)
            {
                ParkingSpaceDbModel model = await ParkingSpaceDbModel.CreateModelFromDb(ids[i]);
                ParkingSpace parkingspace = model.CreateObjectFromModel();
                parkingSpaces[i] = parkingspace;
            }
            return parkingSpaces;
        }
    }
}
