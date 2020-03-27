using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class Person
    {
        public int ID { get; private set; }
        public string Name { get; set; }
        public double Wallet { get; set; }

        public Person(int id, string name, double wallet)
        {
            this.ID = id;
            this.Name = name;
            this.Wallet = wallet;
        }/// <summary>
         /// Converts this type to a type that represents it's database model structure.
         /// </summary>
         /// <returns></returns>
        public PersonDbModel ToDbModel()
        {
            return new PersonDbModel
            {
                Name = this.Name,
                Wallet = this.Wallet
            };
        }
    }
}
