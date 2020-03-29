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
            string[] menuOptions = { "check in", "pay", "check out" };
            SpaceParkCorp spacePark = new SpaceParkCorp(new BankAccountComponent(), new ParkingService(4));
            VisualMenu menu = new VisualMenu(spacePark, menuOptions);

            menu.Start();
        }
    }
}
