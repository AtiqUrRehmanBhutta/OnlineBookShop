using System.ComponentModel.DataAnnotations;

namespace OnlineBookShop.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Introduction { get; set; }
        public string ProfilePictureUrl { get; set; }

        public List<Author_Book> Author_Books { get; set; } = new List<Author_Book>();
    }
}
