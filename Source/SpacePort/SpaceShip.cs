using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
   public class SpaceShip
    {
        public string Name { get; set; }
        //public double Length { get; set; }
        private readonly IEngineComponent engine;
        private readonly IHullComponent passengerModule;
        private readonly IEventLogger shipLog;


         public SpaceShip(string name, double length, int passengerCapacity)
         {
            Name = name;
            //Length = length;
            engine = new EngineComponent();
            passengerModule = new PassengerCarriageComponent
            (
                length, 
                passengerCapacity
            );
            shipLog = new EventLogComponent();
         } 

        public void Park()
        {
            engine.Stop();
        }

        public void IdentifyOwner()
        {
            
        }

        public void Depart()
        {

        }

        public void IsParked()
        {

        }

        public void Communicate()
        {

        }

        public double ShipLength()
        {
            return passengerModule.GetLength();
        }
    }
}
