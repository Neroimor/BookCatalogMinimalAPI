
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
            Book book = context.GetArgument<Book>(0);
            _logger.LogInformation("Processing book with Title: {Title}, Author: {Author}, Price: {Price}, Year: {Year}",
                book.Title, book.Author, book.Price, book.Year);
            return await next(context);
        }
    }
}
