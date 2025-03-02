namespace ECommerceApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "Author name is required.")]
        public string Author { get; set; } = "";

        [Required(ErrorMessage = "Please select a valid Genre.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid Genre.")]
        public int GenreId { get; set; }

        public Genre? Genre { get; set; }  
    }




}
