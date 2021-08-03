using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SFA.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SFA.Data.Mappings
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(c => c.CNPJ)
                .IsRequired()
                .HasColumnType("varchar(14)");

            builder.ToTable("Companies");

        }

    }
}
