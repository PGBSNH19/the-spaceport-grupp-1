using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SpacePort
{
    class Program
    {
        static void Main(string[] args)
        {
            //Testing area!
            System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        }






        public static async Task<SpaceShipModel> GetSpaceShipDataById(int id)
        {
            SpaceShipModel spaceShip = null;

            using (var context = new SpaceParkContext())
            {
                Console.WriteLine("Start GetPerson...");

                spaceShip = await context.SpaceShip.Where(s => s.SpaceShipID == id).FirstOrDefaultAsync<SpaceShipModel>();

                Console.WriteLine("Finished GetPerson...");
            }

            return spaceShip;
        }

        public static void DeleteTableData()
        {
            using (var context = new SpaceParkContext())
            {
                List<SpaceShipModel> tempSList = context.SpaceShip.ToList();
                List<PersonModel> tempPList = context.Person.ToList();

                foreach (var item in tempSList)
                {
                    context.SpaceShip.Remove(item);
                }

                foreach (var item in tempPList)
                {
                    context.Person.Remove(item);
                }

                context.SaveChanges();
            }
        }
    }
}
