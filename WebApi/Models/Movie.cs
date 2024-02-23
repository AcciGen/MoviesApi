namespace WebApi.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Category { get; set; }
        public required string Budget { get; set; }
    }
}
