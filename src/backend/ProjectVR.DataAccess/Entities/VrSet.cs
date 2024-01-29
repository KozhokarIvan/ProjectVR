using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectVR.Domain.Models.VrSet.Validation;

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
            .HasMaxLength(VrSetConstraints.MaxVrSetNameLength)
            .IsRequired();

        builder
            .Property(vrset => vrset.Icon)
            .HasMaxLength(VrSetConstraints.MaxVrSetIconLength)
            .IsRequired(false);
    }
}