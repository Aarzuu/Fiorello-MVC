using Fiorello_Web.Models;

namespace Fiorello_Web.Services.Interfaces
{
    public interface ISliderService
    {
        Task<IEnumerable<Slider>> GetAllAsync();

    }
}
