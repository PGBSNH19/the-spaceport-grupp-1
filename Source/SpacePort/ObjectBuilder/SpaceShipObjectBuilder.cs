using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpacePort
{
    public interface IAddSpaceShipComponents
    {
        IAddSpaceShipComponents AddLength(double length);
        IAddSpaceShipComponents AddShipName(string shipName);
        IAddSpaceShipComponents AddShipID(int primaryKey);
        IAddSpaceShipComponents AddOwner(Person owner);
        //SpaceShip BuildShip();
    }

    public class SpaceShipObjectBuilder : IAddSpaceShipComponents
    {
        private string shipName;
        private double length;
        private int primaryKey;
        private Person owner;

        public SpaceShipObjectBuilder(string name)
        {
            this.shipName = name;
        }

        public static IAddSpaceShipComponents ShipName(string shipName) => new SpaceShipObjectBuilder(shipName);

        public IAddSpaceShipComponents AddLength(double length)
        {
            this.length = length;
            return this;
        }

        public IAddSpaceShipComponents AddShipName(string shipName)
        {
            this.shipName = shipName;
            return this;
        }

        public IAddSpaceShipComponents AddShipID(int id)
        {
            this.primaryKey = id;
            return this;
        }

        public IAddSpaceShipComponents AddOwner(Person owner)
        {
            this.owner = owner;
            return this;
        }

        //public SpaceShip BuildShip()
        //{
        //    return new SpaceShip(this.shipName, this.length, this.primaryKey, this.owner);
        //}

        //public static SpaceShip BuildFromDb(int id)
        //{
        //    SpaceParkContext context = new SpaceParkContext();
        //    SpaceshipDbModel model = SpaceshipDbModel.CreateModelFromDb(id).Result;
        //    Person person = PersonObjectBuilder.BuildFromDataBase(context.SpaceshipInfo.Where(o => o.SpaceshipDbModelId == id).Select(p => p.PersonDbModelId).First());
        //    return SpaceShipObjectBuilder
        //        .ShipName(model.Name)
        //        .AddLength(model.Length)
        //        .AddOwner(person)
        //        .AddShipID(model.SpaceShipID)
        //        .BuildShip();
        //}
    }
}
