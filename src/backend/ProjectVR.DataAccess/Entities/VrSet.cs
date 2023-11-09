using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjectVR.DataAccess.Entities;

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
            .HasMaxLength(Domain.Models.VrSet.MaxVrSetNameLength)
            .IsRequired();

        builder
            .Property(vrset => vrset.Icon)
            .HasMaxLength(Domain.Models.VrSet.MaxVrSetIconLength)
            .IsRequired(false);
    }
}