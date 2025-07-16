using BookCatalogAPI.Models;
using BookCatalogAPI.Services;

namespace TestAPI
{
    public class TestBookService
    {
        private readonly IBookService _bookService;
        public TestBookService()
        {
            _bookService = new BookService(); 
        }

        private Book CreateTestBook(int id)
        {
            return new Book
            {
                Id = id,
                Title = $"Test Book {id}",
                Author = $"Author {id}",
                Price = 9+id,
                Year = 200 + id.ToString()
            };
        }
        private Book UpdateTestBook(int id)
        {
            return new Book
            {
                Id = id,
                Title = $"Updated Test Book {id}",
                Author = $"Updated Author {id}",
                Price = 19 + id,
                Year = 201 + id.ToString()
            };
        }

        [Fact]
        public async Task TestCreateAsync()
        {
            var book = CreateTestBook(1);
            var result = await _bookService.CreateBookAsync(book);
            Assert.NotNull(result);
            Assert.Equal(201, result.StatusCode);
            Assert.Equal(book.Id, result.Book.Id);
            Assert.Equal(book.Title, result.Book.Title);
            Assert.Equal(book.Author, result.Book.Author);
            Assert.Equal(book.Price, result.Book.Price);
            Assert.Equal(book.Year, result.Book.Year);

        }

        [Fact]
        public async Task TestGetByIdAsync()
        {
            var book = CreateTestBook(2);
            await _bookService.CreateBookAsync(book);
            var result = await _bookService.GetBookByIdAsync(2);
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(book.Id, result.Book.Id);
            Assert.Equal(book.Title, result.Book.Title);
            Assert.Equal(book.Author, result.Book.Author);
            Assert.Equal(book.Price, result.Book.Price);
            Assert.Equal(book.Year, result.Book.Year);
        }

        [Fact]
        public async Task TestUpdateAsync()
        {
            var book = CreateTestBook(3);
            await _bookService.CreateBookAsync(book);
            var updatedBook = UpdateTestBook(3);
            var result = await _bookService.UpdateBookAsync(3, updatedBook);
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(updatedBook.Id, result.Book.Id);
            Assert.Equal(updatedBook.Title, result.Book.Title);
            Assert.Equal(updatedBook.Author, result.Book.Author);
            Assert.Equal(updatedBook.Price, result.Book.Price);
            Assert.Equal(updatedBook.Year, result.Book.Year);
        }

        [Fact]
        public async Task TestDeleteAsync()
        {
            var book = CreateTestBook(4);
            await _bookService.CreateBookAsync(book);
            var result = await _bookService.DeleteBookAsync(4);
            Assert.True(result);
            var deletedResult = await _bookService.GetBookByIdAsync(4);
            Assert.Null(deletedResult);
        }



    }
}