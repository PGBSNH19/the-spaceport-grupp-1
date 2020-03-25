using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class PassengerHullComponent : HullComponent
    {
        public List<Person> Passengers { get; private set; } = new List<Person>();
        public int Capacity { get; private set; }

        public PassengerHullComponent(double length, int capacity) : base (length)
        {
            this.Capacity = capacity;
        }

        public bool Embark(Person person)
        {
            if (Passengers.Count < Capacity)
            {
                Passengers.Add(person);
                return true;
            }

            return false;
        }

        public bool Disembark(Person person)
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
