using BookCatalogAPI.Models;

namespace BookCatalogAPI.Services
{
    public interface IBookService
    {

        public Task<IEnumerable<BookQuery>> GetBooksAsync(BookQuery bookQuery, CancellationToken cancellationToken = default);
        public Task<BookQuery?> GetBookByIdAsync(int id, CancellationToken cancellationToken = default);
        public Task<BookQuery?> CreateBookAsync(Book book, CancellationToken cancellationToken = default);
        public Task<BookQuery?> UpdateBookAsync(int id, Book book, CancellationToken cancellationToken = default);
        public Task<bool> DeleteBookAsync(int id, CancellationToken cancellationToken = default);
    }
}
