﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectVR.DataAccess.Entities
{
    public class UserInfo
    {
        public Guid Guid { get; set; }
        public string Username { get; set; } = null!;
        public string? Avatar { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastSeen { get; set; }
        public ICollection<UserGame> Games { get; set; } = new List<UserGame>();
        public ICollection<UserVrSet> VrSets { get; set; } = new List<UserVrSet>();

    }
    internal class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder
                .HasKey(userinfo => userinfo.Guid);

            builder
                .Property(userinfo => userinfo.Username)
                .HasMaxLength(Domain.Models.UserInfo.MaxUsernameLength)
                .IsRequired();

            builder
                .Property(userinfo => userinfo.Avatar)
                .HasMaxLength(Domain.Models.UserInfo.MaxAvatarLength)
                .IsRequired(false);

            builder
                .Property(userinfo => userinfo.CreatedAt)
                .IsRequired();

            builder
                .Property(userinfo => userinfo.LastSeen)
                .IsRequired();

            builder
                .HasMany(userinfo => userinfo.Games)
                .WithOne(game => game.Owner);

            builder
                .HasMany(userinfo => userinfo.VrSets)
                .WithOne(vrset => vrset.Owner);
        }
    }
}