using System;
using System.ComponentModel.DataAnnotations;

namespace Hostel_Management.Models
{
    public class Meeting
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        //[RegularExpression(@"^\d{5}$", ErrorMessage = "Invalid Postal Code")]
        public string PostalCode { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
