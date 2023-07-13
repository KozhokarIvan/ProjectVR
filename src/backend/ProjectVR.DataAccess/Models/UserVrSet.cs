using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ProjectVR.DataAccess.Models
{
    public class UserVrSet
    {
        public int Id { get; set; }
        public UserInfo Owner { get; set; } = null!;
        public Guid OwnerGuid { get; set; }
        public VrSet VrSet { get; set; } = null!;
        public int VrSetId { get; set; }
        public bool IsFavorite { get; set; }
    }
    internal class UserVrSetConfiguration : IEntityTypeConfiguration<UserVrSet>
    {
        public void Configure(EntityTypeBuilder<UserVrSet> builder)
        {
            builder
                .HasKey(uVrSet => uVrSet.Id);

            builder
                .HasOne(uVrSet => uVrSet.Owner)
                .WithMany(user => user.VrSets)
                .HasForeignKey(uVrSet => uVrSet.OwnerGuid);

            builder
                .Property(uVrSet => uVrSet.IsFavorite)
                .IsRequired();

            builder
                .HasOne(uVrSet => uVrSet.VrSet)
                .WithMany()
                .HasForeignKey(vrset => vrset.VrSetId);

            builder.ToTable("uservrsets");
        }
    }
}
