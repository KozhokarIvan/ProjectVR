using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ProjectVR.DataAccess.Models
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
                .IsRequired();

            builder.ToTable("games");
        }
    }
}
