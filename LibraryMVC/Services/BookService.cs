using LibraryAPI.Models.DTOs;

namespace LibraryMVC.Services
{
    public class BookService : BaseService, IBookService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BookService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<T> CreateBookAsync<T>(BookDTO bookDTO)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                apiType = StaticDetails.ApiType.POST,
                Data = bookDTO,
                Url = StaticDetails.BookApiBase + "/api/book",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteBookAsync<T>(int id)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                apiType = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.BookApiBase + "/api/book/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> GetAllBooks<T>()
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                apiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiBase + "/api/books",
                AccessToken = ""
            });
        }

        public async Task<T> GetBookById<T>(int id)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                apiType = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiBase + "/api/book/" + id,
                AccessToken = ""
            });
        }



        public async Task<T> UpdateBookAsync<T>(BookDTO bookDTO)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                apiType = StaticDetails.ApiType.PUT,
                Data = bookDTO,
                Url = StaticDetails.BookApiBase + "/api/book",
                AccessToken = ""
            });
        }
    }
}

