namespace ProjectVR.WebAPI.Contracts.Requests;

public class GetUserVrSetsRequest
{
    public int Limit { get; set; }
    public int? Offset { get; set; }
}