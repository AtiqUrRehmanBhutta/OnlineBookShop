using System.ComponentModel.DataAnnotations;

namespace OnlineBookShop.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength =3, ErrorMessage = "Author name should be in between 3 and 50")]
        public string Name { get; set; }
        public string Introduction { get; set; }
        public string ProfilePictureUrl { get; set; }

        public List<Author_Book> Author_Books { get; set; } = new List<Author_Book>();
    }
}
