using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectVR.DataAccess.Entities
{
    public class Friend
    {
        public int Id { get; set; }
        public UserInfo From { get; set; } = null!;
        public Guid FromUserGuid { get; set; }
        public UserInfo To { get; set; } = null!;
        public Guid ToUserGuid { get; set; }
        public DateTimeOffset AcceptedAt { get; set; }
    }
    internal class FriendsConfiguration : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(friend => friend.From)
                .WithMany(userInfo => userInfo.Friends)
                .HasForeignKey(friend => friend.FromUserGuid);

            builder
                .HasOne(friend => friend.To)
                .WithMany()
                .HasForeignKey(friend => friend.ToUserGuid);

            builder
                .Property(friend => friend.AcceptedAt)
                .IsRequired();
        }
    }
}
