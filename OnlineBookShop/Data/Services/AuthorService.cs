using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext _context;
        public AuthorService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task AddAuthor(Author author)
        {
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthor(Author author)
        {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            var authors = await _context.Authors.ToListAsync();
            return authors;
        }

        public async Task<Author> GetAuthorById(int id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(n => n.Id == id);
            return author;
        }

        public async Task UpdateAuthor(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
        }
    }
}
