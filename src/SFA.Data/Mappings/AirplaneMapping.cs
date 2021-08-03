using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SFA.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.Data.Mappings
{
    public class AirplaneMapping : IEntityTypeConfiguration<Airplane>
    {
        public void Configure(EntityTypeBuilder<Airplane> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.AirplaneModel)
                .IsRequired()
                .HasColumnType("varchar(50)");
            builder.Property(a => a.Capacity)
                .IsRequired();
            builder.Property(a => a.SerialNumber)
                .IsRequired()
                .HasColumnType("varchar(100)");
            builder.Property(a => a.PassengerNumber)
                .IsRequired();

            builder.HasMany(a => a.Seats)
                .WithOne(a => a.Airplane)
                .HasForeignKey(a=> a.AirplaneId);

            builder.HasOne(a => a.Company)
                .WithMany(a => a.Airplanes)
                .HasForeignKey(a => a.CompanyId);

            builder.ToTable("Airplanes");
        }
    }
}
