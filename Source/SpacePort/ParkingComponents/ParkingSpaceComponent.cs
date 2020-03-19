using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class ParkingSpaceComponent : IParkingSpaceComponent
    {
        private bool isOccupied;

        public ParkingSpaceComponent(bool occupied = false)
        {
            this.isOccupied = occupied;
        }

        public virtual void Park()
        {
            isOccupied = true;
        }

        public virtual void Depart()
        {
            isOccupied = false;
        }

        public virtual bool IsOccupied()
        {
            return isOccupied;
        }
    }
}
