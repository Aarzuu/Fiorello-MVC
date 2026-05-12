using Fiorello_Web.Models;

namespace Fiorello_Web.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task CreateAsync(Category category);
        Task DeleteAsync(int id);
    }
}
