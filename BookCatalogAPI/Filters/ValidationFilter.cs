
using BookCatalogAPI.Models;

namespace BookCatalogAPI.Filters
{
    public class ValidationFilter : IEndpointFilter
    {
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            BookQuery? bookQuery = context.GetArgument<BookQuery>(0);
            if (bookQuery?.Book == null)
            {
                return Results.BadRequest("Book cannot be null.");
            }
            if (string.IsNullOrWhiteSpace(bookQuery.Book.Title) || string.IsNullOrWhiteSpace(bookQuery.Book.Author) || bookQuery.Book.Price <= 0 || string.IsNullOrWhiteSpace(bookQuery.Book.Year))
            {
                return Results.BadRequest("Book properties cannot be empty or invalid.");
            }
            if (bookQuery.Book.Id < 0)
            {
                return Results.BadRequest("Book ID cannot be negative.");
            }

            return await next(context);
        }
    }
}
