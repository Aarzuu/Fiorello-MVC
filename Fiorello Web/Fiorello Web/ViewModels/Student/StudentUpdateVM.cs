using System.ComponentModel.DataAnnotations;

namespace Fiorello_Web.ViewModels.Student
{
    public class StudentUpdateVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "You can not leave it blank.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You can not leave it blank.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "You can not leave it blank.")]
        public int Age { get; set; }
        [Required(ErrorMessage = "You can not leave it blank.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "You can not leave it blank.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "You can not leave it blank.")]
        public string Group { get; set; }
        [Required(ErrorMessage = "You can not leave it blank.")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "You can not leave it blank.")]
        public string Faculty { get; set; }
    }
}
