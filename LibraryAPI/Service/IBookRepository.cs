using LibraryAPI.Models;

namespace LibraryAPI.Service
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();

        Task<Book> GetBookByIdAsync(int id);
        Task<Book> GetBookByTitleAsync(string bookTitle);


        Task CreateAsync(Book book);
        Task DeleteAsync(Book book);
        Task UpdateAsync(Book book);

        Task SaveAsync();
    }
}
