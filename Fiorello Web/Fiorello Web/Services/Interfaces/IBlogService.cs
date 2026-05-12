using Fiorello_Web.Models;

namespace Fiorello_Web.Services.Interfaces
{
    public interface IBlogService
    {
        Task<IEnumerable<Blog>> GetAllAsync();

        Task<Blog> GetByIDAsync(int id);

    }
}
