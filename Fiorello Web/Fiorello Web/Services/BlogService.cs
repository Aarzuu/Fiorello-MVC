using Fiorello_Web.Data;
using Fiorello_Web.Models;
using Fiorello_Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_Web.Services
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;
        public BlogService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Blog>> GetAllAsync()
        {
            return await _context.Blogs.Include(b=>b.BlogImages).ToListAsync();
        }

        public async Task<Blog> GetByIDAsync(int id)
        {
            return await _context.Blogs.Include(b => b.BlogImages).FirstOrDefaultAsync(b => b.ID == id);
        }
    }
}
