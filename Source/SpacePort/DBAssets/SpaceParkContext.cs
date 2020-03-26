using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class SpaceParkContext : DbContext
    {
        public DbSet<SpaceShipModel> SpaceShip { get; set; }
        public DbSet<PersonModel> Person { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=MIRKIC-1\SQLEXPRESS;Database=SpacePortDb;Trusted_Connection=True;");
        }
    }
}
