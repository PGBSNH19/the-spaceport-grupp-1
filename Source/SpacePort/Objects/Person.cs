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

        /// <summary>
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
