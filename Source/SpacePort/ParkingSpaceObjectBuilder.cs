using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpacePort
{
    public interface IAddParkingSpaceComponents
    {
        IAddParkingSpaceComponents AddSpaceShip(SpaceShip spaceShip);
        IAddParkingSpaceComponents AddOccupied(bool occupied);

        ParkingSpaceModel BuildParkingSpace();
    }

    public class ParkingSpaceObjectBuilder : IAddParkingSpaceComponents
    {
        private int id;
        private SpaceShip spaceShip;
        private bool occupied;

        public ParkingSpaceObjectBuilder(int id)
        {
            this.id = id;
        }

        public static IAddParkingSpaceComponents AddID(int id) => new ParkingSpaceObjectBuilder(id);

        public IAddParkingSpaceComponents AddSpaceShip(SpaceShip spaceShip)
        {
            this.spaceShip = spaceShip;
            return this;
        }

        public IAddParkingSpaceComponents AddOccupied(bool occupied)
        {
            this.occupied = occupied;
            return this;
        }

        public ParkingSpaceModel BuildParkingSpace()
        {
            return new ParkingSpaceModel(this.id, this.spaceShip, this.occupied);
        }

        public static ParkingSpaceModel BuildFromDb(int id)
        {
            SpaceParkContext context = new SpaceParkContext();
            ParkingSpaceModel model = ParkingSpaceModel.CreateModelFromDb(id).Result;
            SpaceShip spaceShip = SpaceShipObjectBuilder.BuildFromDb(context.SpaceShip.Where(o => o.SpaceShipID == id).Select(p => p.Owner.PersonID).First());
            return ParkingSpaceObjectBuilder
                   .AddID(model.ParkingSpaceID)
                   .AddSpaceShip(spaceShip)
                   .AddOccupied(model.Occupied)
                   .BuildParkingSpace();
                
                
        }
    }
}
