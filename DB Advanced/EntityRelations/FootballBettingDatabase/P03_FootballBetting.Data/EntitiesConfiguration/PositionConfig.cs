using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.EntitiesConfiguration
{
    public class PositionConfig : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.Property(x => x.Name)
                    .IsRequired()
                    .IsUnicode();

            builder.HasMany(x => x.Players)
                    .WithOne(x => x.Position)
                    .HasForeignKey(x => x.PositionId);
        }
    }
}
