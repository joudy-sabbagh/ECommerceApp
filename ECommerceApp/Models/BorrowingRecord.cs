namespace ECommerceApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BorrowingRecord
    {
        public int BorrowingRecordId { get; set; }

        [Required(ErrorMessage = "Borrow date is required.")]
        public DateTime BorrowDate { get; set; }

        public DateTime? ReturnDate { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid Member.")]
        public int MemberId { get; set; }

        public Member? Member { get; set; }   

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid Book.")]
        public int BookId { get; set; }

        public Book? Book { get; set; }
    }    
 
}
