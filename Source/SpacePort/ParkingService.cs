﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpacePort;
using System.Threading.Tasks;

namespace SpacePort
{
    public class ParkingService
    {
        private ParkingSpace[] parkingSpaces;
        private readonly ApiDataFetch apiDataFetch;
        public ParkingService(int parkingSpaces)
        {
            this.apiDataFetch = new ApiDataFetch();
            this.parkingSpaces = ParkingSpace.GetParkingSpaceAsync(parkingSpaces).Result.ToArray();
            if (ParkingSpace.GetParkingSpaceAsync(parkingSpaces).Result.ToArray().Count() < 1)
            {
                for (int i = 0; i < this.parkingSpaces.Length; i++)
                {
                    this.parkingSpaces[i] = new ParkingSpace();
                }
            }
        }

        public bool AllowedPerson(Person person)
        {
            return apiDataFetch.GetPeople(person.Name).count >= 1;
        }

        public bool AllowedShipLength(Spaceship spaceship)
        {
            return spaceship.Length <= 120000;
        }

        public bool FreeParkingSpace()
        {
            using (var context = new SpaceParkContext())
            {
                return parkingSpaces.Where(p => p.OccupyingSpaceship == null) != null;
            }
        }

        public void ParkSpaceship(Person person, Spaceship spaceship)
        {
            if(parkingSpaces.Length < 1)
            {
                return;
            }

            Person.AddPersonToDb(person);

            using(var context = new SpaceParkContext())
            {
                ParkingSpace parkingSpace = parkingSpaces.Where(p => p.OccupyingSpaceship == null).FirstOrDefault();
                parkingSpace.OccupyingSpaceship = spaceship;
                var parkSpace = context.Parkingspace.Where(p => p.ParkingSpaceID == parkingSpace.ParkingSpaceID).First();
                var s = context.Spaceship.Where(s => s.SpaceshipID == spaceship.SpaceshipID).First();
                var p = context.Person.Where(p => p.Name == person.Name).First();
                p.Spaceship = s;
                parkSpace.Spaceship = s;
                
                context.SaveChanges();
                
            }            
        }

        public bool DepartSpaceShip(Spaceship spaceship, Person person)
        {
            using (var context = new SpaceParkContext())
            {
                ParkingSpace parkingSpace = parkingSpaces.Where(p => p.OccupyingSpaceship.SpaceshipID == spaceship.SpaceshipID).First();
                parkingSpace.OccupyingSpaceship = null;
                var parkSpace = context.Parkingspace.Where(p => p.ParkingSpaceID == parkingSpace.ParkingSpaceID).First();
                parkSpace.Spaceship = null;
                parkSpace.SpaceshipID = null;
                
                context.SaveChanges();
                Spaceship.DeleteSpaceshipFromDb(spaceship);
                //Person.DeletePersonFromDb(person);
                return true;
            }
        }
    }
}
