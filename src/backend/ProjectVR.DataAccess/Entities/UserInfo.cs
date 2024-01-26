using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectVR.Domain.Models.User.Validation;

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
    public ICollection<Friend> OutgoingRequests { get; set; } = new List<Friend>();
    public ICollection<Friend> IncomingRequests { get; set; } = new List<Friend>();
}

internal class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
{
    public void Configure(EntityTypeBuilder<UserInfo> builder)
    {
        builder
            .HasKey(userinfo => userinfo.Guid);

        builder
            .Property(userinfo => userinfo.Username)
            .HasMaxLength(UserValidationConstraints.MaxUsernameLength)
            .IsRequired();

        builder
            .Property(userinfo => userinfo.Avatar)
            .HasMaxLength(UserValidationConstraints.MaxAvatarLength)
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
            .WithOne(vrSet => vrSet.Owner)
            .HasForeignKey(vrSet => vrSet.OwnerGuid);

        builder
            .HasMany(userinfo => userinfo.OutgoingRequests)
            .WithOne(friend => friend.From)
            .HasForeignKey(friend => friend.FromUserGuid);

        builder
            .HasMany(userinfo => userinfo.IncomingRequests)
            .WithOne(friend => friend.To)
            .HasForeignKey(friend => friend.ToUserGuid);
    }
}