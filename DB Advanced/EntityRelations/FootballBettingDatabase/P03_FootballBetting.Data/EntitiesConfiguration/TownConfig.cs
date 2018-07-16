﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.EntitiesConfiguration
{
    public class TownConfig : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .IsUnicode();

            builder.HasMany(x => x.Teams)
                .WithOne(x => x.Town)
                .HasForeignKey(x => x.TownId);

        }
    }
}
