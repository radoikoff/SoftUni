using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_HospitalDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data.EntitiesConfiguration
{
    public class MedicamentConfig : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(e => e.MedicamentId);

            builder.Property(p => p.Name)
                   .HasMaxLength(50)
                   .IsUnicode();

            builder.HasMany(p => p.Prescriptions)
                .WithOne(p => p.Medicament)
                .HasForeignKey(p => p.MedicamentId);
        }
    }
}
