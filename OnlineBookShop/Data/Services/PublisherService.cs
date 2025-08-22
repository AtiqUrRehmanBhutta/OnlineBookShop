using Microsoft.EntityFrameworkCore;
using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly AppDbContext _context;
        public PublisherService(AppDbContext context) 
        {
            _context = context;
        }
        public async Task AddPublisher(Publisher publisher)
        {
            await _context.Publishers.AddAsync(publisher);
            await _context.SaveChangesAsync();
        }
        public async Task DeletePublisher(Publisher publisher)
        {
            _context.Publishers.Remove(publisher);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Publisher>> GetAllPublishers()
        {
            var publishers = await _context.Publishers.ToListAsync();
            return publishers;
        }
        public async Task<Publisher> GetPublisherById(int id)
        {
            var publisher = await _context.Publishers.FirstOrDefaultAsync(n => n.Id == id);
            return publisher;
        }
        public async Task UpdatePublisher(Publisher publisher)
        {
            _context.Publishers.Update(publisher);
            await _context.SaveChangesAsync();
        }
       
    }
}
