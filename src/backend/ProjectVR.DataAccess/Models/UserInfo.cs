using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ProjectVR.DataAccess.Models
{
    public class UserInfo
    {
        public Guid Guid { get; set; }
        public string Username { get; set; } = null!;
        public string? Avatar { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset LastSeen { get; set; }
        public List<UserGame> Games { get; set; } = new List<UserGame>();
        public List<UserVrSet> VrSets { get; set; } = new List<UserVrSet>();

    }
    internal class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
    {
        public void Configure(EntityTypeBuilder<UserInfo> builder)
        {
            builder
                .HasKey(userinfo => userinfo.Guid);

            builder
                .Property(userinfo => userinfo.Username)
                .IsRequired();

            builder
                .Property(userinfo => userinfo.Avatar)
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

            builder.ToTable("usersinfo");
        }
    }
}
