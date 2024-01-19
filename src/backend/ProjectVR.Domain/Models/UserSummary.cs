using System;
using System.Collections.Generic;
using ProjectVR.Domain.Models.Enums;

namespace ProjectVR.Domain.Models;

public class UserSummary : UserBase
{
    public ICollection<UserGame> Games { get; set; } = Array.Empty<UserGame>();
    public ICollection<UserVrSet> VrSets { get; set; } = Array.Empty<UserVrSet>();
}