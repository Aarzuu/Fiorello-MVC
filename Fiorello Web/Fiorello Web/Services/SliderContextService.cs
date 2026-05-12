using Fiorello_Web.Data;
using Fiorello_Web.Models;
using Fiorello_Web.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_Web.Services
{
    public class SliderContextService : ISliderContextService
    {
        private readonly AppDbContext _context;
        public SliderContextService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<SliderContext> GetContextAsync()
        {
            return await _context.SliderContexts.FirstOrDefaultAsync();
        }
    }
}
