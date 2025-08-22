using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task AddBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(Book book);
    }
}
