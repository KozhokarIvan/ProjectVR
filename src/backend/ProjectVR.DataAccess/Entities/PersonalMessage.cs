using System;

namespace ProjectVR.DataAccess.Entities;

public class PersonalMessage
{
    public int Id { get; set; }
    public PersonalChat Chat { get; set; } = null!;
    public int ChatId { get; set; }
    public UserInfo From { get; set; } = null!;
    public Guid FromUserGuid { get; set; }
    public string Content { get; set; } = string.Empty;
    public DateTimeOffset SentAt { get; set; }
    public DateTimeOffset EditedAt { get; set; }
}