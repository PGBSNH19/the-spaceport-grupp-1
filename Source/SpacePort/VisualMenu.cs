using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace SpacePort
{
    public class VisualMenu
    {
        private SpaceParkCorp spacePark;
        private List<Spaceship> spaceships;
        private string[] menuOptions;
        private Person person;
        private Spaceship spaceship;
        private List<string> EventLog;

        public VisualMenu(SpaceParkCorp spacePark, string[] menuOptions)
        {
            this.spacePark = spacePark;
            this.spaceships = Spaceship.GetSpaceShipsAsync().Result;
            this.menuOptions = menuOptions;
            this.EventLog = new List<string>();
        }
        public void Start()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            if (PrintValidateIntegrity(ValidateIntegrity(name)))
            {
                Menu(MenuOptions("Welcome to SpaceParkCorp", menuOptions), this.person, this.spaceship);
            }

        }

        public void Menu(string menuOption, Person person, Spaceship spaceship)
        {
            bool isRunning = true;
            while (isRunning)
            {
                switch (menuOption)
                {
                    case "check in":
                        if (PrintAllowedToPark(spacePark.CheckIn(person, spaceship, EventLog)))
                        {
                            Menu(MenuOptions("pay", this.menuOptions), person, spaceship);
                        }
                        isRunning = false;
                        break;
                    case "pay":
                        if (PrintHasMoney(spacePark.ValidateCustomerPayment(person, spaceship, EventLog)))
                        {
                            Menu(MenuOptions("check out", this.menuOptions), person, spaceship);
                        }
                        isRunning = false;
                        break;
                    case "check out":
                        if (PrintCheckout(spacePark.CheckOut(spaceship, this.EventLog)))
                        {
                            isRunning = false;
                        }
                        else
                        {
                            Menu(MenuOptions("check out", this.menuOptions), person, spaceship);
                        }
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
        public bool ValidateIntegrity(string name)
        {
            this.person = new Person(name, 200);
            bool isValid = Person.PersonExistInDb(this.person);
            if (isValid)
            {
                string shipName = MenuOptions("Select your spaceship:", spaceships.Where(s => s.Owner == null).Select(s => s.Name).ToArray());
                this.spaceship = SpaceshipModel.CreateModelFromDb(shipName).Result.CreateObjectFromModel();
                this.spaceship.Owner = this.person;
                return isValid;
            }
            return isValid;
        }

        private bool PrintAllowedToPark(bool allowed)
        {
            foreach (var log in this.EventLog)
            {
                Console.WriteLine(log);
                Thread.Sleep(00);
            }
            this.EventLog = new List<string>();
            Console.ReadKey();
            return allowed;
        }

        private bool PrintHasMoney(bool hasMoney)
        {
            foreach (var log in this.EventLog)
            {
                Console.WriteLine(log);
                Thread.Sleep(500);
            }
            this.EventLog = new List<string>();
            Console.ReadKey();
            return hasMoney;

        }

        public bool PrintValidateIntegrity(bool isValid)
        {
            if (isValid)
            {
                Console.WriteLine("Your name is valid");
            }
            else
            {
                Console.WriteLine("Your name is already in use, are u scammer?!!");
            }
            return isValid;
        }
        private bool PrintCheckout(bool isCheckedOut)
        {
            if (isCheckedOut)
            {
                Console.WriteLine("We did successfully check you out");
            }
            else
            {
                Console.WriteLine("Something went wrong with the checkout");
            }
            Console.ReadKey();
            return isCheckedOut;

        }
    }
}
