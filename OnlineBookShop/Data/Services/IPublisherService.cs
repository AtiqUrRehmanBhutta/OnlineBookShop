using OnlineBookShop.Models;

namespace OnlineBookShop.Data.Services
{
    public interface IPublisherService
    {
        Task<IEnumerable<Publisher>> GetAllPublishers();
        Task<Publisher> GetPublisherById(int id);
        Task AddPublisher(Publisher publisher);
        Task UpdatePublisher(Publisher publisher);
        Task DeletePublisher(Publisher publisher);
    }
}
