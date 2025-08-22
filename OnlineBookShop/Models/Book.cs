using OnlineBookShop.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBookShop.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        [Display(Name = "Category")]
        public BookCategory BookCategory { get; set; }

        [Display(Name = "Picture Url")]
        public string ProfilePictureUrl { get; set; }

        // Relationships

        //Many-to-many relationship with Author
        public List<Author_Book> Author_Books { get; set; } = new List<Author_Book>();

        // One-to-many relationship with Publisher
        public int PublisherId { get; set; }
        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
    }
}
