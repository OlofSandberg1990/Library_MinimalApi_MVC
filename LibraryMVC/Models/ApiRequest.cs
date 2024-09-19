using static LibraryMVC.StaticDetails;

namespace LibraryMVC.Models
{
    public class ApiRequest
    {
        public ApiType apiType { get; set; }
        public Object Data { get; set; }
        public string Url { get; set; }
        public string AccessToken { get; set; }
    }
}
