using LibraryAPI.Data;
using LibraryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Service
{
    public class BookRepository : IBookRepository
    {

        private readonly AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task CreateAsync(Book book)
        {
            await _appDbContext.Books.AddAsync(book);
        }

        public async Task DeleteAsync(Book book)
        {
            _appDbContext.Books.Remove(book);
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _appDbContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _appDbContext.Books.FirstOrDefaultAsync(b => b.BookId == id);
        }

        public async Task<Book> GetBookByTitleAsync(string bookTitle)
        {
            return await _appDbContext.Books.FirstOrDefaultAsync(b => b.Title.ToLower() == bookTitle.ToLower());
        }

        public async Task SaveAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _appDbContext.Update(book);
        }
    }
}
