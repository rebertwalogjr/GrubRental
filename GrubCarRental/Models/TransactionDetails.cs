namespace GrubCarRental.Models
{
    public class TransactionDetails
    {
        public int TransactionId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
