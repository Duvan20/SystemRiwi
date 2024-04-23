namespace SystemRiwi.Models
{
    public class Historical
    {
        public int Id { get; set; }
        public DateTime? EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public string Status { get; set; }
        public int User_id { get; set; }

        public User User { get; set; }
    }
}