using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SFA.Business.Models;

namespace SFA.Data.Mappings
{
    public class SeatMapping : IEntityTypeConfiguration<Seat>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Seat> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Number)
                .IsRequired();
            builder.Property(s => s.TypeClass)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.ToTable("Seats");

        }
    }
}
