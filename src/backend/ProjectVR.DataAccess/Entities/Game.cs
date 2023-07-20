using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectVR.DataAccess.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Icon { get; set; } = null!;
    }

    internal class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder
                .HasKey(game => game.Id);

            builder
                .Property(game => game.Name)
                .HasMaxLength(Domain.Models.Game.MaxGameNameLength)
                .IsRequired();

            builder
                .Property(game => game.Icon)
                .HasMaxLength(Domain.Models.Game.MaxGameIconLength)
                .IsRequired(false);
        }
    }
}
