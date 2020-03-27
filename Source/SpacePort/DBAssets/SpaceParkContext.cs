﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpacePort
{
    public class SpaceParkContext : DbContext
    {
        public DbSet<SpaceshipDbModel> SpaceshipInfo { get; set; }
        public DbSet<PersonDbModel> PersonInfo { get; set; }
        public DbSet<ParkingSpaceDbModel> ParkingSpaceInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-2IS2C3L\SQLEXPRESS; Database=SpacePortDB; Trusted_Connection=True;");
        }
    }
}
