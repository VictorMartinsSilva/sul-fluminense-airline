using Microsoft.EntityFrameworkCore;
using SFA.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFA.Data.Context
{
    public class SfaDbContext : DbContext
    {
        public SfaDbContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Seat> Seats { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Scheduling> Schedules { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<SchedulingPassenger> SchedulingPassengers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SfaDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

    }
}
