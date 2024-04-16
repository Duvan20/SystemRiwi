namespace SystemRiwi.Models
{
    public class History
    {
        public int Id { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
        public string? Status { get; set; }
        public int User_id { get; set; }
    }
}