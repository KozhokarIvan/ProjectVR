﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectVR.DataAccess.Entities;

public class UserGame
{
    public int Id { get; set; }

    public Users Owner { get; set; } = null!;

    public Guid OwnerGuid { get; set; }

    public Game Game { get; set; } = null!;

    public int GameId { get; set; }

    public bool IsFavorite { get; set; }

    public byte? Rating { get; set; }
}

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
    }
}