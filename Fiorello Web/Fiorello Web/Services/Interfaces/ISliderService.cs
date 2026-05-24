using Fiorello_Web.Models;
using Fiorello_Web.ViewModels.Slider;

namespace Fiorello_Web.Services.Interfaces
{
    public interface ISliderService
    {
        Task<IEnumerable<Slider>> GetAllAsync();
        Task<IEnumerable<SliderVM>> GetAllAdminAsync();
        Task CreateAsync(SliderCreateVM model);
        Task<SliderDetailVM> GetByIDAsync(int id);
        Task DeleteAsync(int id);
        Task UpdateAsync(int? id, SliderUpdateVM? model);
    }
} 
