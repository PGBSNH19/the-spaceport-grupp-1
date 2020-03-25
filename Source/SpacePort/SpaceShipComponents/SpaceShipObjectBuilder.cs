using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public interface IAddSpaceShipComponents
    {
        IAddSpaceShipComponents AddEngine(EngineComponent engine);
        IAddSpaceShipComponents AddShipLog(EventLogComponent shipLog);
        IAddSpaceShipComponents AddPassengerComponent(PassengerHullComponent passengerModule);
        SpaceShip BuildShip();
    }

    public class SpaceShipObjectBuilder : IAddSpaceShipComponents
    {
        private string name;
        private EngineComponent engine;
        private EventLogComponent shipLog;
        private PassengerHullComponent passengerComponent;

        public SpaceShipObjectBuilder(string name)
        {
            this.name = name;
        }

        public static SpaceShip BuildFromApi(int id)
        {
            ApiDataFetch data = new ApiDataFetch();
            var spaceShipData = data.GetSpaceShip(id);

            return SpaceShipObjectBuilder
                .ShipName(spaceShipData.name)
                .AddEngine(new EngineComponent())
                .AddShipLog(new EventLogComponent())
                .AddPassengerComponent(new PassengerHullComponent(double.Parse(spaceShipData.length), int.Parse(spaceShipData.passengers)))
                .BuildShip();
        }

        public static SpaceShip BuildFromApi(string name)
        {
            ApiDataFetch data = new ApiDataFetch();
            var spaceShipData = data.GetSpaceShip(name);

            return SpaceShipObjectBuilder
                .ShipName(spaceShipData.name)
                .AddEngine(new EngineComponent())
                .AddShipLog(new EventLogComponent())
                .AddPassengerComponent(new PassengerHullComponent(double.Parse(spaceShipData.length), int.Parse(spaceShipData.passengers)))
                .BuildShip();
        }
        public static IAddSpaceShipComponents ShipName(string name) => new SpaceShipObjectBuilder(name);

        public IAddSpaceShipComponents AddEngine(EngineComponent engine)
        {
            this.engine = engine;
            return this;
        }

        public IAddSpaceShipComponents AddPassengerComponent(PassengerHullComponent passengerComponent)
        {
            this.passengerComponent = passengerComponent;
            return this;
        }

        public IAddSpaceShipComponents AddShipLog(EventLogComponent shipLog)
        {
            this.shipLog = shipLog;
            return this;
        }

        public SpaceShip BuildShip()
        {
            return new SpaceShip(this.name, this.engine, this.shipLog, this.passengerComponent);
        }
    }
}
