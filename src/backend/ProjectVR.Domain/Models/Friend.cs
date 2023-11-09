using System;

namespace ProjectVR.Domain.Models;

public class Friend
{
    public int Id { get; init; }
    public Guid SenderUserGuid { get; init; }
    public Guid AccepterUserGuid { get; init; }
}