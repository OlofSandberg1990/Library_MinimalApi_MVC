using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]        
        public string Title { get; set; }
        [Required]        
        public string Author { get; set; }
        public int Published { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public bool AvaliableForLoan { get; set; } = true;
    }
}
