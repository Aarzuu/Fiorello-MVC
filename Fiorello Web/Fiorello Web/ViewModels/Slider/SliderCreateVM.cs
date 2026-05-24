using System.ComponentModel.DataAnnotations;

namespace Fiorello_Web.ViewModels.Slider
{
    public class SliderCreateVM
    {
        [Required(ErrorMessage = "Please upload an image here.")]
        public IFormFile Image { get; set; }
    }
}
