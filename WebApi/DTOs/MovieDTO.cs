namespace WebApi.DTOs
{
    public class MovieDTO
    {
        public required string Title { get; set; }
        public required string Category { get; set; }
        public required long Budget { get; set; }
    }
}
