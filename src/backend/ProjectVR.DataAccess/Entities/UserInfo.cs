using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectVR.Domain.Models;

namespace ProjectVR.DataAccess.Entities;

public class UserInfo
{
    public Guid Guid { get; set; }
    public string Username { get; set; } = null!;
    public string? Avatar { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset LastSeen { get; set; }
    public ICollection<UserGame> Games { get; set; } = new List<UserGame>();
    public ICollection<UserVrSet> VrSets { get; set; } = new List<UserVrSet>();
    public ICollection<Friend> Friends { get; set; } = new List<Friend>();
}

internal class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
{
    public void Configure(EntityTypeBuilder<UserInfo> builder)
    {
        builder
            .HasKey(userinfo => userinfo.Guid);

        builder
            .Property(userinfo => userinfo.Username)
            .HasMaxLength(UserSummary.MaxUsernameLength)
            .IsRequired();

        builder
            .Property(userinfo => userinfo.Avatar)
            .HasMaxLength(UserSummary.MaxAvatarLength)
            .IsRequired(false);

        builder
            .Property(userinfo => userinfo.CreatedAt)
            .IsRequired();

        builder
            .Property(userinfo => userinfo.LastSeen)
            .IsRequired();

        builder
            .HasMany(userinfo => userinfo.Games)
            .WithOne(game => game.Owner)
            .HasForeignKey(game => game.OwnerGuid);

        builder
            .HasMany(userinfo => userinfo.VrSets)
            .WithOne(vrset => vrset.Owner)
            .HasForeignKey(vrset => vrset.OwnerGuid);

        builder
            .HasMany(userinfo => userinfo.Friends)
            .WithOne(friend => friend.From)
            .HasForeignKey(friend => friend.FromUserGuid);
    }
}