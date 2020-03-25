using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class SpaceShip
    {
        public string Name { get; set; }

        private readonly EngineComponent engine;
        private readonly EventLogComponent shipLog;
        private readonly PassengerHullComponent passengerComponent;

        public SpaceShip(string name, EngineComponent engine, EventLogComponent shipLog, PassengerHullComponent passengerComponent)
        {
            this.Name = name;
            this.engine = engine;
            this.shipLog = shipLog;
            this.passengerComponent = passengerComponent;
        }

        public void StartEngine()
        {
            engine.Start();
            shipLog.WriteToEventLog("Engine fired up!");
        }

        public void StopEngine()
        {
            engine.Stop();
            shipLog.WriteToEventLog("Engine powered down.");
        }

        public bool IsEngineOn()
        {
            return engine.IsRunning();
        }

        public void AddShipLogEntry(string message)
        {
            shipLog.WriteToEventLog(message);
        }

        public List<string> GetShipLog()
        {
            return shipLog.GetEventLog();
        }

        public bool AddPassenger(Person passenger)
        {
            bool passengerBoarded = passengerComponent.Embark(passenger);
            if (passengerBoarded)
            {
                shipLog.WriteToEventLog($"{passenger.Name} boarded ship.");
                return true;
            }

            shipLog.WriteToEventLog($"{passenger.Name} cannot board because ship is at full capacity.");

            return false;            
        }

        public bool RemovePassenger(Person passenger)
        {
            bool passengerDisembarked = passengerComponent.Disembark(passenger);
            if (passengerDisembarked)
            {
                shipLog.WriteToEventLog($"{passenger.Name} disembarked ship.");
                return true;
            }

            shipLog.WriteToEventLog($"There's noone named {passenger.Name} onboard.");

            return false;
        }

        public bool RemovePassenger(string name)
        {
            bool passengerDisembarked = passengerComponent.Disembark(name);
            if (passengerDisembarked)
            {
                shipLog.WriteToEventLog($"{name} disembarked ship.");
                return true;
            }

            shipLog.WriteToEventLog($"There's no-one named {name} on-board.");

            return false;
        }

        public int PassengerCapacity()
        {
            return passengerComponent.Capacity;
        }

        public int PassengerCount()
        {
            return passengerComponent.Passengers.Count;
        }

        public List<Person> PassengerList()
        {
            return passengerComponent.Passengers;
        }

        public double GetShipLength()
        {
            return passengerComponent.GetLength();
        }
    }
}

