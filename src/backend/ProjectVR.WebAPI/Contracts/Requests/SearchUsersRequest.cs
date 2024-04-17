using System.Runtime.Serialization;

namespace ProjectVR.WebAPI.Contracts.Requests;

public class SearchUsersRequest
{
    [DataMember(Name = "query")]
    public string SearchQuery { get; init; } = string.Empty;

    public int Limit { get; init; }

    public int Offset { get; init; }
}