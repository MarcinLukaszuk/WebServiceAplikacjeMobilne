using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebServiceAplikacjeMobilne.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("Name=DefaultConnection") { }
        public DbSet<Event> Events { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<EventCompetition> EventsCompetition { get; set; }
        public DbSet<Shooter> Shooters { get; set; }
        public DbSet<ShooterEventCompetition> ShootersEventCompetition { get; set; }
        public DbSet<Shoot> Shoots { get; set; }
    }
}