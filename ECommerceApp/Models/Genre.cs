namespace ECommerceApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Genre
    {
        public int GenreId { get; set; }

        [Required(ErrorMessage = "Genre name is required.")]
        [StringLength(50, ErrorMessage = "Genre name cannot exceed 50 characters.")]
        public string Name { get; set; } = "";
    }


}
