using Fiorello_Web.Models;
using Fiorello_Web.ViewModels.Category;

namespace Fiorello_Web.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryUIVM>> GetAllAsync();
        Task<IEnumerable<CategoryVM>> GetAllAdminAsync();
        Task CreateAsync(CategoryCreateVM category);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, CategoryUpdateVM category);
        Task<CategoryDetailVM> GetByIDAsync(int id);        
    }
}
