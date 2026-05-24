using Fiorello_Web.Data;
using Fiorello_Web.Models;
using Fiorello_Web.Services.Interfaces;
using Fiorello_Web.ViewModels.Category;
using Fiorello_Web.ViewModels.Student;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_Web.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(CategoryCreateVM category)
        {
            await _context.Categories.AddAsync(new Category { Name = category.Name});
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c=>c.ID==id);
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryVM>> GetAllAdminAsync()
        {
            return await _context.Categories.Include(p => p.Products).Select(c => new CategoryVM {ID = c.ID,Name = c.Name }).ToListAsync();
        }

        public async Task<IEnumerable<CategoryUIVM>> GetAllAsync()
        {
            return await _context.Categories.Include(p=>p.Products).Select(c=> new CategoryUIVM {Name = c.Name}).ToListAsync();
        }

        public async Task<CategoryDetailVM> GetByIDAsync(int id)
        {
            var category  = await _context.Categories.FirstOrDefaultAsync(c => c.ID == id);
            return new CategoryDetailVM { ID = category.ID, Name = category.Name};
        }

        public async Task UpdateAsync(int id, CategoryUpdateVM category)
        {
            var data = await _context.Categories.FirstOrDefaultAsync(c=>c.ID == id);
            data.Name = category.Name;
            await _context.SaveChangesAsync();
        }
    }
}
