using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class SpaceShipObjectBuilder : IAddComponents
    {
        private string name;
        private EngineComponent engine;
        private EventLogComponent shipLog;
        private PassengerCarriageComponent passengerModule;

        public SpaceShipObjectBuilder(string name)
        {
            this.name = name;
        }

        public static IAddComponents ShipName(string name) => new SpaceShipObjectBuilder(name);

        public IAddComponents AddEngine(EngineComponent engine)
        {
            this.engine = engine;
            return this;
        }

        public IAddComponents AddPassengerModule(PassengerCarriageComponent passengerModule)
        {
            this.passengerModule = passengerModule;
            return this;
        }

        public IAddComponents AddShipLog(EventLogComponent shipLog)
        {
            this.shipLog = shipLog;
            return this;
        }

        public SpaceShip BuildShip()
        {
            return new SpaceShip(this.name, this.engine, this.shipLog, this.passengerModule);
        }
    }

    public interface IAddComponents
    {
        IAddComponents AddEngine(EngineComponent engine);
        IAddComponents AddShipLog(EventLogComponent shipLog);
        IAddComponents AddPassengerModule(PassengerCarriageComponent passengerModule);
        SpaceShip BuildShip();
    }


}
