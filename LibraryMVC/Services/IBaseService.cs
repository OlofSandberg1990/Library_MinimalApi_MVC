using LibraryMVC.Models;

namespace LibraryMVC.Services
{
    public interface IBaseService
    {
        ResponseDTO responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
