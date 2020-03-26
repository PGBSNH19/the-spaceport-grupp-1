using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SpacePort
{
    public class Person
    {
       
        public int PersonID { get; set; }
        public string Name { get; set; }
        public double Wallet { get; set; }
        public Person(string name, double wallet) {
            Name = name;
            Wallet = wallet;
        }

        public int Pay()
        {
            throw new NotImplementedException();
            //return 1;
        }
    }
}
