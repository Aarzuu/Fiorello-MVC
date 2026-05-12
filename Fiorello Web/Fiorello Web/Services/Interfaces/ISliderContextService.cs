using Fiorello_Web.Models;

namespace Fiorello_Web.Services.Interfaces
{
    public interface ISliderContextService
    {
        Task<SliderContext> GetContextAsync();

    }
}
