using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectVR.DataAccess.Models.Configurations
{
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
