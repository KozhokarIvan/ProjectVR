namespace ProjectVR.WebAPI.Contracts.Requests
{
    public class SearchUsersRequest
    {
        public string SearchQuery { get; set; } = string.Empty;
        public int Limit { get; set; }
        public int Offset { get; set; }
    }
}
