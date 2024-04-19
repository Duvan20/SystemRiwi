namespace SystemRiwi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender{ get; set; }
        public string Occupation { get; set; }
        public string Document { get; set; }
        public string document_type { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public List<History>History { get; set; }
    }
}