using Fiorello_Web.ViewModels.Expert;

namespace Fiorello_Web.Services.Interfaces
{
    public interface IExpertService
    {
        Task<IEnumerable<ExpertUIVM>> GetAllAsync();
        Task<IEnumerable<ExpertVM>> GetAllAdminAsync();
        Task CreateAsync(ExpertCreateVM model);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id,ExpertUpdateVM model);
        Task<ExpertDetailVM> GetByIDAsync(int id);
    }
}
