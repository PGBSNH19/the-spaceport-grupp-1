using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class SpaceShipObjectBuilder : IStart, IAddComponents
    {
        public IAddComponents NameShip()
        {
            throw new NotImplementedException();
        }

        public IAddComponents AddEngine()
        {
            throw new NotImplementedException();
        }

        public IAddComponents AddPassengerModule()
        {
            throw new NotImplementedException();
        }

        public IAddComponents AddShipLog()
        {
            throw new NotImplementedException();
        }

        public SpaceShip BuildShip()
        {
            throw new NotImplementedException();
        }
    }

    public interface IStart
    {
        IAddComponents NameShip();
    }

    public interface IAddComponents
    {
        IAddComponents AddEngine();
        IAddComponents AddShipLog();
        IAddComponents AddPassengerModule();
        SpaceShip BuildShip();
    }


}
