using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class PassengerCarriageComponent : HullComponent
    {
        public List<Character> Passengers { get; private set; } = new List<Character>();
        public int Capacity { get; private set; }

        public PassengerCarriageComponent(double length, int capacity) : base (length)
        {
            this.Capacity = capacity;
        }

        public bool Embark(Character person)
        {
            if (Passengers.Count < Capacity)
            {
                Passengers.Add(person);
                return true;
            }

            return false;
        }

        public bool Disembark(Character person)
        {
            int passengerCount = Passengers.Count;
            Passengers.Remove(Passengers.Find(p => p == person));

            if (passengerCount != Passengers.Count)
            {
                return true;
            }

            return false;
        }

        public bool Disembark(string name)
        {
            int passengerCount = Passengers.Count;
            Passengers.Remove(Passengers.Find(p => p.Name == name));

            if (passengerCount != Passengers.Count)
            {
                return true;
            }

            return false;
        }
    }
}
