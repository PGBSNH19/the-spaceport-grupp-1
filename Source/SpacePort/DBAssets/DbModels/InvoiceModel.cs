using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SpacePort
{
    public class InvoiceModel
    {
        [Key]
        public int InvoiceID { get; private set; }
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created { get; set; }
        
        public double Price { get; set; }
        [ForeignKey("PersonID")]
        public PersonModel Person { get; set; }

        [ForeignKey("SpaceshipID")]
        public SpaceshipModel Spaceship { get; set; }


    }
}
