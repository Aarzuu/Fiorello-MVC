using System.ComponentModel.DataAnnotations;

namespace Fiorello_Web.ViewModels.Expert
{
    public class ExpertCreateVM
    {
        [Required]
        public IFormFile Image { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Profession { get; set; }
    }
}
