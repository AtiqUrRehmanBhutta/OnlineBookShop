namespace OnlineBookShop.Models
{
    public class Author_Book
    {
        // This class represents the many-to-many relationship between Author and Book
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
