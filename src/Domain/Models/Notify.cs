namespace Domain.Models
{
    public class Notify
    {
        public int Id { get; set; }
        public Coffee? Coffee { get; set; }
        public int Progress { get; set; }
    }
}
