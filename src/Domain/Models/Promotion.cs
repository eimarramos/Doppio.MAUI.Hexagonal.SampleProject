namespace Domain.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public Shop? Shop { get; set; }
        public Coffee? Coffee { get; set; }
        public DateTimeOffset Expiration { get; set; }
    }
}
