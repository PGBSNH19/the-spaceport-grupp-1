using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class DBContext : DbContext
    {
        public DbSet<SpaceShip> SpaceShips { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-MGQ777UR\SQLEXPRESS;Database=SpaceCorpDb; Trusted_Connection=True;");
        }
    }
}
