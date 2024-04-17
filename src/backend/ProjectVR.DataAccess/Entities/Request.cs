using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectVR.DataAccess.Entities;

public class Request
{
    public int Id { get; set; }

    public Users From { get; set; } = null!;

    public Guid FromUserGuid { get; set; }

    public Users To { get; set; } = null!;

    public Guid ToUserGuid { get; set; }

    public DateTimeOffset? AcceptedAt { get; set; }
}

internal class RequestsConfiguration : IEntityTypeConfiguration<Request>
{
    public void Configure(EntityTypeBuilder<Request> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .HasOne(friend => friend.From)
            .WithMany(userInfo => userInfo.OutgoingRequests)
            .HasForeignKey(friend => friend.FromUserGuid);

        builder
            .HasOne(friend => friend.To)
            .WithMany(userInfo => userInfo.IncomingRequests)
            .HasForeignKey(friend => friend.ToUserGuid);

        builder
            .Property(friend => friend.AcceptedAt)
            .IsRequired(false);
    }
}