using camera.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace camera.DAL
{
    public class TLSContext : DbContext
    {
        public TLSContext() : base("TLSContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<parking> Parking { get; set; }
        public DbSet<customer> Customer { get; set; }
        public DbSet<carpark> Carpark { get; set; }
        public DbSet<carparkprovider> Carparkprovider { get; set; }
        public DbSet<customeraccount> Customeraccount { get; set; }
        public DbSet<rate> Rate { get; set; }
        public DbSet<ratetype> Ratetype { get; set; }
        public DbSet<vehicle> Vehicle { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}