using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ProjectVR.DataAccess.Models
{
    public class VrSet
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Icon { get; set; } = null!;
    }
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
