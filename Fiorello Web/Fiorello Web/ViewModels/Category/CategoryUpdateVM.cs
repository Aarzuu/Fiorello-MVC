using System.ComponentModel.DataAnnotations;

namespace Fiorello_Web.ViewModels.Category
{
    public class CategoryUpdateVM
    {
        [Required]
        public string Name { get; set; }
    }
}
