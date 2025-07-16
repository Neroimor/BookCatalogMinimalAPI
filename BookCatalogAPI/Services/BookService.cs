using BookCatalogAPI.Models;
using System.Collections.Concurrent;

namespace BookCatalogAPI.Services
{
    public class BookService : IBookService
    {
        private static readonly ConcurrentDictionary<int, Book> _books = new ConcurrentDictionary<int, Book>();

        public async Task<BookQuery?> CreateBookAsync(Book book, CancellationToken cancellationToken = default)
        {
            await Task.Delay(100, cancellationToken); 
            _books.TryAdd(book.Id, book);
            var bookQuery = new BookQuery { Book = book, StatusCode = 201 }; 


            throw new NotImplementedException();
        }

        public async Task<bool> DeleteBookAsync(int id, CancellationToken cancellationToken = default)
        {
            await Task.Delay(100, cancellationToken);
            if (_books.TryRemove(id, out _))
            {
                return true;
            }
            return false;
        }

        public async Task<BookQuery?> GetBookByIdAsync(int id, CancellationToken cancellationToken = default)
        {

            await Task.Delay(100, cancellationToken);
            if (_books.TryGetValue(id, out var book))
            {
                return new BookQuery { Book = book, StatusCode = 200 };
            }
            return null;
        }

        public async Task<IEnumerable<BookQuery>> GetBooksAsync(BookQuery bookQuery, CancellationToken cancellationToken = default)
        {
            await Task.Delay(100, cancellationToken);
            var books = _books.Values.Select(b => new BookQuery { Book = b, StatusCode = 200 }).ToList();
            return books;
        }

        public async Task<BookQuery?> UpdateBookAsync(int id, Book book, CancellationToken cancellationToken = default)
        {
            await Task.Delay(100, cancellationToken);
            if (_books.TryGetValue(id, out var existingBook))
            {
                book.Id = id;
                _books[id] = book;
                return new BookQuery { Book = book, StatusCode = 200 };
            }
            return null; 
        }
    }

}
