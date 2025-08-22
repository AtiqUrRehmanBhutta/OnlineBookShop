using System.ComponentModel.DataAnnotations;

namespace OnlineBookShop.Models
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Introduction { get; set; }
        public string ProfilePictureUrl { get; set; }

        //Relationships
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
