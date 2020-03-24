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
        private readonly PassengerCarriageComponent passengerModule;

        public SpaceShip(string name, EngineComponent engine, EventLogComponent shipLog, PassengerCarriageComponent passengerModule)
        {
            Name = name;
            this.engine = engine;
            this.shipLog = shipLog;
            this.passengerModule = passengerModule;
        }

        public void StartEngine()
        {
            engine.Start();
            shipLog.WriteToLog("Engine fired up!");
        }

        public void StopEngine()
        {
            engine.Stop();
            shipLog.WriteToLog("Engine powered down.");
        }

        public bool IsEngineOn()
        {
            return engine.IsRunning();
        }

        public void AddLogEntry(string message)
        {
            shipLog.WriteToLog(message);
        }

        public List<string> GetShipLog()
        {
            return shipLog.GetLog();
        }

        public bool AddPassenger(Person passenger)
        {
            bool passengerBoarded = passengerModule.Embark(passenger);
            if (passengerBoarded)
            {
                shipLog.WriteToLog($"{passenger.Name} boarded ship.");
                return true;
            }

            shipLog.WriteToLog($"{passenger.Name} cannot board because ship is at full capacity.");
            return false;            
        }

        public bool RemovePassenger(Person passenger)
        {
            bool passengerDisembarked = passengerModule.Disembark(passenger);
            if (passengerDisembarked)
            {
                shipLog.WriteToLog($"{passenger.Name} disembarked ship.");
                return true;
            }

            shipLog.WriteToLog($"There's noone named {passenger.Name} onboard.");
            return false;
        }

        public bool RemovePassenger(string passengerName)
        {
            bool passengerDisembarked = passengerModule.Disembark(passengerName);
            if (passengerDisembarked)
            {
                shipLog.WriteToLog($"{passengerName} disembarked ship.");
                return true;
            }

            shipLog.WriteToLog($"There's no-one named {passengerName} on-board.");
            return false;
        }

        public int PassengerCapacity()
        {
            return passengerModule.Capacity;
        }

        public int PassengerCount()
        {
            return passengerModule.Passengers.Count;
        }

        public List<Person> PassengerList()
        {
            return passengerModule.Passengers;
        }

        public double GetShipLength()
        {
            return passengerModule.GetLength();
        }
    }
}

