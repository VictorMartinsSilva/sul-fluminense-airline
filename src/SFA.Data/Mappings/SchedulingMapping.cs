using System;
using System.Collections.Generic;
using System.Text;
using SFA.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace SFA.Data.Mappings
{
    class SchedulingMapping : IEntityTypeConfiguration<Scheduling>
    {
        public void Configure(EntityTypeBuilder<Scheduling> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.HandBaggage)
                .IsRequired();

            builder.Property(s => s.CheckedBaggage)
                .IsRequired();

            builder.HasOne(s => s.Flights)
                .WithMany(s => s.Schedules)
                .HasForeignKey(s => s.FlightId);

            builder.HasOne(s => s.Seats)
                .WithMany(s => s.Schedules)
                .HasForeignKey(s => s.SeatId);

            builder.ToTable("Schedules");

        }
    }
}
