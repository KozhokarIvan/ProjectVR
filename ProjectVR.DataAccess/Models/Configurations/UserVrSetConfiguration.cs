using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectVR.DataAccess.Models.Configurations
{
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
