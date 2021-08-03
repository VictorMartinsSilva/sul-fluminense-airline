using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SFA.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.Data.Mappings
{
    public class FlightsMapping : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Origin)
                .IsRequired()
                .HasColumnType("varchar(42)");

            builder.Property(f => f.Destiny)
                .IsRequired()
                .HasColumnType("varchar(42)");

            builder.HasOne(f => f.AirPlanes)
                .WithMany(f => f.Flights)
                .HasForeignKey(f => f.AirPlaneId);

            builder.ToTable("Flights");
        }
    }
}
