namespace Domain.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public Shop? Shop { get; set; }
        public Coffee? Coffee { get; set; }
        public DateTimeOffset Expiration { get; set; }
        public string ExpirationString
        {
            get
            {
                var now = DateTimeOffset.UtcNow;
                var timeRemaining = Expiration - now;

                if (timeRemaining.TotalSeconds <= 0)
                {
                    return "Expired";
                }

                if (timeRemaining.TotalHours < 24)
                {
                    return $"Expires in {Math.Floor(timeRemaining.TotalHours)} hours";
                }

                return $"Expires in {Math.Floor(timeRemaining.TotalDays)} days";
            }
        }
    }
}
