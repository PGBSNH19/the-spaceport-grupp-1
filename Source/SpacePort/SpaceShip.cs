using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class SpaceShip
    {
        public string Name { get; set; }

        private readonly IEngineComponent engine;
        private readonly IEventLogComponent shipLog;
        private readonly IHullComponent passengerModule;

        public SpaceShip(string name, double length, int passengerCapacity)
        {
            Name = name;
            engine = new EngineComponent();
            shipLog = new EventLogComponent();
            passengerModule = new PassengerCarriageComponent(length, passengerCapacity);
        }


    }
}

