using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GrubCarRental.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        [Required(ErrorMessage = "Brand is required.")]
        public string? Brand { get; set; }

        public int? Year { get; set; }

        [DisplayName("Model")]
        public string? Type { get; set; }
        public string? Transmission { get; set; }

        [Required(ErrorMessage = "Plate number must not be empty.")]
        [DisplayName("Plate number")]
        public string PlateNumber { get; set; }

        [DisplayName("Number of seat")]
        public int? SeatNumber { get; set; }
    }
}
