namespace BookCatalogAPI.Models
{
    public record class BookQuery
    {
        public Book? Book { get; set; }
        public int StatusCode { get; set; } = 200;
    }
}
