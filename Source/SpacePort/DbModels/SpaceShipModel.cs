using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SpacePort
{
    public class SpaceShipModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpaceShipID { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public PersonModel Owner { get; set; }
    }
}
