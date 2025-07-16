
using BookCatalogAPI.Models;

namespace BookCatalogAPI.Filters
{
    public class LoggingFilter : IEndpointFilter
    {
        private readonly ILogger<LoggingFilter> _logger;
        public LoggingFilter(ILogger<LoggingFilter> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {
            var book = context.Arguments.FirstOrDefault(a => a is Book) as Book;
            if (book is null)
            {
                // Ничего не делаем, если Book в сигнатуре не присутствует
                return await next(context);
            }
            _logger.LogInformation("Processing book with Title: {Title}, Author: {Author}, Price: {Price}, Year: {Year}",
                book.Title, book.Author, book.Price, book.Year);
            return await next(context);
        }
    }
}
