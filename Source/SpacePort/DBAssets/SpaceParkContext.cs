using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class SpaceParkContext : DbContext
    {
        public DbSet<SpaceshipModel> Spaceship { get; set; }
        public DbSet<PersonModel> Person { get; set; }
        public DbSet<ParkingSpaceModel> Parkingspace { get; set; }
        public DbSet<InvoiceModel> Invoice { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-2IS2C3L\SQLEXPRESS; Database=SpacePortDB; Trusted_Connection=True;");
        }
    }
}
