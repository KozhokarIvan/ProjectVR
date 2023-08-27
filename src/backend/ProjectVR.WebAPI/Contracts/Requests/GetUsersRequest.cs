namespace ProjectVR.WebAPI.Contracts.Requests
{
    public class GetUsersRequest
    {
        public string? Game { get; init; }
        public string? VrSet { get; init; }
        public int Offset { get; init; }
        public int Limit { get; init; }
    }
}