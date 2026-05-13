using Fiorello_Web.ViewModels.Student;

namespace Fiorello_Web.Services.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentUIVM>> GetAllAsync();
        Task<IEnumerable<StudentVM>> GetAllAdminAsync();
        Task CreateAsync(StudentCreateVM createStudent);
        Task UpdateAsync(int id, StudentUpdateVM updateStudent);
        Task DeleteAsync(int id);
        Task<StudentDetailVM> GetByID(int id);
    }
}
