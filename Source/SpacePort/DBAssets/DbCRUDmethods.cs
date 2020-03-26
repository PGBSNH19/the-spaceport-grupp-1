using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpacePort
{
    public static class DbCRUDmethods
    {
        public static void AddToDatabase(Person person, SpaceParkContext context)
        {
            using (context)
            {
                if (!context.Person.Any(p => p.Name == person.Name))
                {
                    context.Person.Add(new PersonModel { Name = person.Name, Wallet = person.Wallet });
                }
                else
                {
                    context.Person.Update(new PersonModel { Name = person.Name, Wallet = person.Wallet });
                }
            }
        }

        public static void AddToDatabase(SpaceShip spaceShip, SpaceParkContext context)
        {
            using (context)
            {
                if (!context.SpaceShip.Any(p => p.Name == spaceShip.Name))
                {
                    context.SpaceShip.Add(new SpaceShipModel { Name = spaceShip.Name, Length = spaceShip.Length, Owner = new PersonModel { Name = spaceShip.Owner.Name, Wallet = spaceShip.Owner.Wallet } });
                }
            }
        }
    }
}
