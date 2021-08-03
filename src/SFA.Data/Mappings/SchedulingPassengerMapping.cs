using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SFA.Business.Models;

namespace SFA.Data.Mappings
{
    public class SchedulingPassengerMapping : IEntityTypeConfiguration<SchedulingPassenger>
    {
        public void Configure(EntityTypeBuilder<SchedulingPassenger> builder)
        {
            builder.HasKey(sp => sp.Id);

            builder.HasOne(sp => sp.Passenger)
                .WithMany(sp => sp.SchedulingPassengers)
                .HasForeignKey(sp => sp.PassengerId);

            builder.HasOne(sp => sp.Scheduling)
                .WithMany(sp => sp.SchedulingPassengers)
                .HasForeignKey(sp => sp.SchedulingId);

            builder.ToTable("SchedulingPassengers");
        }
    }
}
