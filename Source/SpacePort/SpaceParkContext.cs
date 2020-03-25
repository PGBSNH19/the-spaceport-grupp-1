using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class SpaceParkContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<SpaceShip> Spaceship { get; set; }
      



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-0F2VCI2\SQLEXPRESS;Database=SpacePortDb;Trusted_Connection=True;");
        }
    }
}
