namespace Hostel_Management.Models
{
    public class Room
    {
        public int RoomId { get; set; }  // Unique identifier for the room
        public string RoomNumber { get; set; }  // Room number or name
        public int Capacity { get; set; }  // Number of occupants the room can accommodate
        public bool IsOccupied { get; set; }  // Indicates if the room is currently occupied
        public decimal PricePerMonth { get; set; }  // Rental price per month
        //public string Description { get; set; }  // Additional details about the room
        public string RoomType { get; set; }  // E.g., Single, Double, Suite
        public string Image { get; set; }
        // Foreign key to the User who manages this room
        public int UserId { get; set; }
        public User User { get; set; }  // Navigation property to the User
    }
}
