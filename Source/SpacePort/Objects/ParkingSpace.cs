﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class ParkingSpace
    {
        public int ID { get; private set; }
        public Spaceship OccupyingSpaceship { get; set; }

        /// <summary>
        /// Converts this type to a type that represents it's database model structure.
        /// </summary>
        /// <returns></returns>
        public ParkingSpaceDbModel ToDbModel()
        {
            if (OccupyingSpaceship != null)
            {
                return new ParkingSpaceDbModel
                {
                    SpaceshipDbModel = this.OccupyingSpaceship.ToDbModel()
                };
            }

            return new ParkingSpaceDbModel();
        }
    }
}