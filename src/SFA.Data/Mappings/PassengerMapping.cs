using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SFA.Business.Models;
namespace SFA.Data.Mappings
{
    public class PassengerMapping : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Document)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.Property(p => p.Passport)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(p => p.Image)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("Passengers");
        }
    }
}
