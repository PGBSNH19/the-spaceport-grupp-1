using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class SpaceParkContext : DbContext
    {
<<<<<<< HEAD
        public DbSet<SpaceshipDbModel> SpaceshipInfo { get; set; }
        public DbSet<PersonDbModel> PersonInfo { get; set; }
        public DbSet<ParkingSpaceDbModel> ParkingSpaceInfo { get; set; }
=======
        public DbSet<SpaceShipModel> SpaceShip { get; set; }
        public DbSet<PersonModel> Person { get; set; }
        public DbSet<ParkingSpaceModel> ParkingSpace { get; set; }

>>>>>>> refs/remotes/origin/master

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=LAPTOP-MGQ777UR\SQLEXPRESS; Database=TestDb1337; Trusted_Connection=True;");
        }
    }
}
