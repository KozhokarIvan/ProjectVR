using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectVR.Domain.Models.Game.Validation;

namespace ProjectVR.DataAccess.Entities;

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
            .HasMaxLength(GameConstraints.MaxGameNameLength)
            .IsRequired();

        builder
            .Property(game => game.Icon)
            .HasMaxLength(GameConstraints.MaxGameIconLength)
            .IsRequired(false);
    }
}