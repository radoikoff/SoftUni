using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.EntitiesConfiguration
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Name)
                    .IsRequired()
                    .IsUnicode(true);

            builder.Property(x => x.Username)
                    .IsRequired();

            builder.Property(x => x.Password)
                    .IsRequired();

            builder.HasMany(x => x.Bets)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.UserId);
        }
    }
}
