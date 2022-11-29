using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrubCarRental.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }

        [Required]
        [DisplayName("Borrow Date")]
        public DateTime BorrowedDate { get; set; }

        [Required]
        [DisplayName("Return Date")]
        public DateTime ReturnDate { get; set; }

        [Required]
        [DisplayName("Car Id")]
        public int CarId { get; set; }
        
        [Required]
        [DisplayName("Renter Id")]
        public int RenterId { get; set; }
    }
}
