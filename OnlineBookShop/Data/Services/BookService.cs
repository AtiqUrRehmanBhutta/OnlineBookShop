using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;
        public BookService(AppDbContext context) 
        {
            _context = context;
        }
        public async Task AddBook(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }
        public async Task<Book> GetBookById(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(n => n.Id == id);
            return book;
        }
        public async Task UpdateBook(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
       
    }
}
