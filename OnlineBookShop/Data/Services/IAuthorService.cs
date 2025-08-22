using OnlineBookShop.Models;
using System.Collections.Generic;
namespace OnlineBookShop.Data.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(int id);
        Task AddAuthor(Author author);
        Task UpdateAuthor(Author author);
        Task DeleteAuthor(Author author);

    }
}
