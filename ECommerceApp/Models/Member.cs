namespace ECommerceApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Member
    {
        public int MemberId { get; set; }

        [Required(ErrorMessage = "Member name is required.")]
        public string Name { get; set; } = "";

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; } = "";

        [Required]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Phone number must be 8 digits.")]
        public string PhoneNumber { get; set; } = "";

        public ICollection<BorrowingRecord> BorrowingRecords { get; set; } = new List<BorrowingRecord>();

    }


}