using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SpacePort
{
    public class Person
    {
        public int PersonID { get; private set; }
        public string Name { get; set; }
        public double Wallet { get; set; }
        
        public Person(int personID, string name, double wallet) 
        {
            this.PersonID = personID;
            Name = name;
            Wallet = wallet;
        }
    }
}
