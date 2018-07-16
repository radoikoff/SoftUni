﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data.EntitiesConfig
{
    public class ResourceConfig : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.Property(x => x.Name)
                    .HasMaxLength(50)
                    .IsUnicode()
                    .IsRequired();

            builder.Property(x => x.Url)
                    .IsUnicode(false)
                    .IsRequired();

        }
    }
}
