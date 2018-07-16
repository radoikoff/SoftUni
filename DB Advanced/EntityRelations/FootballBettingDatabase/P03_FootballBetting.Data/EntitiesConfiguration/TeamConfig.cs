using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data.EntitiesConfiguration
{
    public class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.Property(x => x.Name)
                    .IsRequired()
                    .IsUnicode();

            builder.Property(x => x.LogoUrl)
                    .IsUnicode(false);

            builder.Property(x => x.Initials)
                    .HasMaxLength(3)
                    .IsUnicode();

            builder.HasMany(x => x.HomeGames)
                    .WithOne(x => x.HomeTeam)
                    .HasForeignKey(x => x.HomeTeamId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.AwayGames)
                   .WithOne(x => x.AwayTeam)
                   .HasForeignKey(x => x.AwayTeamId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Players)
                    .WithOne(x => x.Team)
                    .HasForeignKey(x => x.TeamId)
                    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
