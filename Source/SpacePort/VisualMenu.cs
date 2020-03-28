using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SpacePort
{
    public class VisualMenu
    {
        private SpaceParkCorp spacePark;
        private List<Spaceship> spaceships;
        private List<Person> people;
        private string[] menuOptions;
        private Person person;
        private Spaceship spaceship;
        public VisualMenu(SpaceParkCorp spacePark, List<Person> people, List<Spaceship> spaceships, string[] menuOptions)
        {
            this.spacePark = spacePark;
            this.people = people;
            this.spaceships = spaceships;
            this.menuOptions = menuOptions;
        }
        public VisualMenu(SpaceParkCorp spacePark, string[] menuOptions)
        {
            this.spacePark = spacePark;
            this.people = Person.GetPeopleAsync().Result;
            this.spaceships = Spaceship.GetSpaceShipsAsync().Result;
            this.menuOptions = menuOptions;
        }
        public void Start()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            string shipName = MenuOptions("Select your spaceship:", spaceships.Where(s => s.Owner == null).Select(s => s.Name).ToArray());
            this.person = new Person(name, 200);
            this.spaceship = SpaceshipDbModel.CreateModelFromDb(shipName).Result.CreateObjectFromModel();
            this.spaceship.Owner = this.person;
            Menu(MenuOptions("Welcome to SpaceParkCorp", menuOptions), this.person, this.spaceship);
        }

        public void Menu(string menuOptions, Person person, Spaceship spaceship)
        {
            bool isRunning = true;
            while (isRunning)
            {
                switch (menuOptions)
                {
                    case "check in":
                        PrintAllowedToPark(spacePark.CheckIn(person, spaceship));
                        menuOptions = "pay";
                        break;
                    case "pay":
                        PrintHasMoney(spacePark.ValidateCustomer(person.Wallet));
                        menuOptions = "check out";
                        break;
                    case "check out":
                        spacePark.CheckOut(spaceship);
                        isRunning = false;
                        break;
                    case "4":
                        break;
                }
            }
        }

        static string MenuOptions(string prompt, string[] options)
        {
            Console.Clear();
            Console.WriteLine(prompt);
            int selected = 0;

            Console.CursorVisible = false;

            ConsoleKey? key = null;
            while (key != ConsoleKey.Enter)
            {

                if (key != null)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = Console.CursorTop - options.Length;
                }


                for (int i = 0; i < options.Length; i++)
                {
                    var option = options[i];
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine("- " + option);
                    Console.ResetColor();
                }


                key = Console.ReadKey().Key;
                if (key == ConsoleKey.DownArrow)
                {
                    selected = Math.Min(selected + 1, options.Length - 1);
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    selected = Math.Max(selected - 1, 0);
                }
            }

            Console.CursorVisible = true;
            return options[selected];
        }

        private void PrintAllowedToPark(bool allowed)
        {
            if (allowed)
            {
                Console.WriteLine("We successfully parked your ship!");
            }
            else
            {
                Console.WriteLine("your ship did not meet the criterias");
            }

        }

        private void PrintHasMoney(bool hasMoney)
        {
            if(hasMoney)
            {
                Console.WriteLine("has money");
            }
            else
            {
                Console.WriteLine("has no money");
            }
        }

        private void PrintCheckout()
        {
            
        }
    }
}
