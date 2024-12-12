namespace BookClub1._1.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public List<Book> ReadBooks { get; set; }
    }
}
