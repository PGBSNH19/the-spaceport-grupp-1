using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class SpaceShipObjectBuilder : IStart, IAddComponents
    {
        private string name;
        private EngineComponent engine;
        private EventLogComponent shipLog;
        private PassengerCarriageComponent passengerModule;

        public int MyProperty { get; set; }
        public SpaceShipObjectBuilder()
        {

        }
        public IAddComponents NameShip()
        {
            return this;
        }

        public IAddComponents AddEngine()
        {
            return this;
        }

        public IAddComponents AddPassengerModule()
        {
            return this;
        }

        public IAddComponents AddShipLog()
        {
            return this;
        }

        public SpaceShip BuildShip()
        {
            return new SpaceShip;
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
