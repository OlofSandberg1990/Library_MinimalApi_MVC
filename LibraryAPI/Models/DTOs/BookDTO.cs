using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.DTOs
{
    public class BookDTO
    {
        public int BookId { get; set; }

        [Required(ErrorMessage = "Title is required")]

        public string Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Publish year is required")]
        public int Published { get; set; }

        [Required(ErrorMessage = "Genre is required")]

        public string Genre { get; set; }

        [Required(ErrorMessage = "Description is required")]

        public string Description { get; set; }

        public bool AvaliableForLoan { get; set; } = true;
    }
}
