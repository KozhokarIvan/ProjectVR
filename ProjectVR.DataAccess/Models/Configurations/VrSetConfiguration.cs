using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectVR.DataAccess.Models.Configurations
{
    internal class VrSetConfiguration : IEntityTypeConfiguration<VrSet>
    {
        public void Configure(EntityTypeBuilder<VrSet> builder)
        {
            builder
                .HasKey(vrset => vrset.Id);

            builder
                .Property(vrset => vrset.Name)
                .IsRequired();

            builder.ToTable("vrsets");
        }
    }
}
