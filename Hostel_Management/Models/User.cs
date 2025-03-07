namespace Hostel_Management.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Phonenumber { get; set; }
        public string Password { get; set; }
        public ICollection<Staff> Staffmembers { get; set; }
        // Navigation property for the rooms managed by the user
        public ICollection<Room> Rooms { get; set; }

    }
}
