namespace ProjectVR.WebAPI.Contracts.Requests
{
    public class GetUsersRequest
    {
        public string? Game { get; set; }
        public string? VrSet { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}