
using BookCatalogAPI.Models;

namespace BookCatalogAPI.Filters
{
    public class ValidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var book = context.Arguments.FirstOrDefault(a => a is Book) as Book;
            if (book is null)
            {
                // Ничего не делаем, если Book в сигнатуре не присутствует
                return await next(context);
            }

            if (book == null)
            {
                context.HttpContext.Response.StatusCode = 400;
                return new BookQuery { StatusCode = 400, Book = null };
            }
            if (string.IsNullOrWhiteSpace(book.Title) || string.IsNullOrWhiteSpace(book.Author))
            {
                context.HttpContext.Response.StatusCode = 400;
                return new BookQuery { StatusCode = 400, Book = null };
            }
            if (book.Price <= 0 || string.IsNullOrWhiteSpace(book.Year) || !int.TryParse(book.Year, out _))
            {
                context.HttpContext.Response.StatusCode = 400;
                return new BookQuery { StatusCode = 400, Book = null };
            }


            return await next(context);
        }
    }
}
