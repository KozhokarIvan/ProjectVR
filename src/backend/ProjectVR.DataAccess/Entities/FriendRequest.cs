using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectVR.DataAccess.Entities
{
    public class FriendRequest
    {
        public int Id { get; set; }
        public UserInfo From { get; set; } = null!;
        public Guid FromUserGuid { get; set; }
        public UserInfo To { get; set; } = null!;
        public Guid ToUserGuid { get; set; }
        public DateTimeOffset SentAt { get; set; }
    }
    internal class FriendRequestConfiguration : IEntityTypeConfiguration<FriendRequest>
    {
        public void Configure(EntityTypeBuilder<FriendRequest> builder)
        {
            builder
                .HasKey(request => request.Id);

            builder
                .HasOne(request => request.From)
                .WithMany(userinfo => userinfo.OutgoingFriendRequests)
                .HasForeignKey(request => request.FromUserGuid);

            builder
                .HasOne(request => request.To)
                .WithMany(userinfo => userinfo.IncomingFriendRequests)
                .HasForeignKey(request => request.ToUserGuid);

            builder
                .Property(request => request.SentAt)
                .IsRequired();
        }
    }
}
