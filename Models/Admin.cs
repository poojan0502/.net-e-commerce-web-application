namespace Group_Project.Models
{
    public class Admin
    {
        public int AdminId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } // In production, store passwords securely (hashed).
    }
}
