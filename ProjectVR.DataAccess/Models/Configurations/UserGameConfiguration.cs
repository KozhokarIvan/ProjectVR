using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectVR.DataAccess.Models.Configurations
{
    internal class UserGameConfiguration : IEntityTypeConfiguration<UserGame>
    {
        public void Configure(EntityTypeBuilder<UserGame> builder)
        {
            builder
                .HasKey(usergame => usergame.Id);

            builder
                .HasOne(usergame => usergame.Owner)
                .WithMany(user => user.Games)
                .HasForeignKey(usergame => usergame.OwnerGuid);

            builder.HasOne(usergame => usergame.Game)
                .WithMany()
                .HasForeignKey(usergame => usergame.GameId);

            builder
                .Property(usergame => usergame.Rating)
                .IsRequired(false);

            builder
                .Property(usergame => usergame.IsFavorite)
                .IsRequired();

            builder.ToTable("usergames");
        }
    }
}
