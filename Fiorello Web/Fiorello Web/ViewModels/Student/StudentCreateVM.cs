using System.ComponentModel.DataAnnotations;

namespace Fiorello_Web.ViewModels.Student
{
    public class StudentCreateVM
    {
        [Required(ErrorMessage = "You can not leave ite blank.")]
        [MaxLength(30, ErrorMessage = "Max length is 30.")]
        [MinLength(4, ErrorMessage = "Min length is 4.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You can not leave it blank.")]
        [MaxLength(45, ErrorMessage = "Max length is 45.")]
        [MinLength(8, ErrorMessage = "Min length is 8.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "You can not leave it blank.")]
        public int Age { get; set; }
        [Required(ErrorMessage = "You can not leave it blank.")]
        [EmailAddress]
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
