using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GrubCarRental.Models
{
    public class Renter
    {
        [Key]
        public int RenterId { get; set; }

        [Required(ErrorMessage = "Please fill the first name.")]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please fill the last name.")]
        [DisplayName("Last name")]
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string? LicenseNumber { get; set; }

    }
}