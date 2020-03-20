using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        public void Embark(Character person)
        {
            if (Passengers.Count < Capacity)
            {
                Passengers.Add(person);
            }
        }

        public void Disembark(Character person)
        {
            Passengers.Remove(Passengers.Find(p => p == person));
        }

        public void Disembark(string name)
        {
            Passengers.Remove(Passengers.Find(p => p.Name == name));
        }
    }
}
