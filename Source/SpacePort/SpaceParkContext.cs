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
        public DbSet<EngineComponent> Engine {get;set; }
        public DbSet<EventLogComponent> EventLog { get; set; }
        public DbSet<PassengerHullComponent> PassengerComponent { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=MIRKIC-1\SQLEXPRESS;Database=SpacePortDb;Trusted_Connection=True;");
        }
    }
}
