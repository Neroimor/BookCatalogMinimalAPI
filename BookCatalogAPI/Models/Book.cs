namespace BookCatalogAPI.Models
{
    public record class Book
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public string Year { get; set; }
    }
}
