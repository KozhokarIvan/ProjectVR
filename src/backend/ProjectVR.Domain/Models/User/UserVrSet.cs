namespace ProjectVR.Domain.Models.User;

public class UserVrSet
{
    public int VrSetId { get; set; }
    public string VrSetName { get; set; } = null!;
    public string VrSetIcon { get; set; } = null!;
    public bool IsFavorite { get; set; }
}