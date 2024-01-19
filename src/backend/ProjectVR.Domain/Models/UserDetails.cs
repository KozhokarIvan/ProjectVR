using System;
using System.Collections.Generic;

namespace ProjectVR.Domain.Models;

public class UserDetails : UserSummary
{
    public ICollection<UserBase> Friends { get; set; } = Array.Empty<UserBase>();
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset LastSeen { get; set; }
}