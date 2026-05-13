using Fiorello_Web.Data;
using Fiorello_Web.Models;
using Fiorello_Web.Services.Interfaces;
using Fiorello_Web.ViewModels.Student;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_Web.Services
{
    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;
        public StudentService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(StudentCreateVM createStudent)
        {
            await _context.AddAsync(new Student { Name = createStudent.Name, Surname = createStudent.Surname,
            Age = createStudent.Age, Email = createStudent.Email, Address = createStudent.Address,
            Group = createStudent.Group, PhoneNumber = createStudent.PhoneNumber,Faculty = createStudent.Faculty});

            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentVM>> GetAllAdminAsync()
        {
            var students = await _context.Students.Select(s => new StudentVM { Name = s.Name, Surname = s.Surname, Email = s.Email, Age = s.Age, ID =s.ID }).ToListAsync();
            return students;
        }

        public Task<IEnumerable<StudentUIVM>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<StudentDetailVM> GetByID(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.ID == id);
            return new StudentDetailVM { Name=student.Name, Surname=student.Surname, Age=student.Age, 
                ID =student.ID, Email = student.Email,Address = student.Address, Group=student.Group, 
                PhoneNumber=student.PhoneNumber, Faculty=student.Faculty };
        }

        public Task UpdateAsync(int id, StudentUpdateVM updateStudent)
        {
            throw new NotImplementedException();
        }
    }
}
