using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SFA.Business.Models;

namespace SFA.Data.Mappings
{
    public class AddressMapping : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Street)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(a => a.District)
                .IsRequired()
                .HasColumnType("varchar(100)");
            
            builder.Property(a => a.Complement)
                .HasColumnType("varchar(250)");
            
            builder.Property(a => a.PostalCode)
                .IsRequired()
                .HasColumnType("varchar(9)");

            builder.Property(a => a.City)
                .IsRequired()
                .HasColumnType("varchar(100)");
            
            builder.Property(a => a.State)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(a => a.Number)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(a => a.UF)
                .IsRequired()
                .HasColumnType("varchar(2)");


            builder.ToTable("Addresses");
        }
    }
}
