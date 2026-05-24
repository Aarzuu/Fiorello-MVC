using Fiorello_Web.Data;
using Fiorello_Web.Models;
using Fiorello_Web.Services.Interfaces;
using Fiorello_Web.ViewModels.Expert;
using Fiorello_Web.ViewModels.Slider;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace Fiorello_Web.Services
{
    public class ExpertService : IExpertService
    {
        private readonly AppDbContext _context;
        private readonly IFileService _fileService;
        public ExpertService(AppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task CreateAsync(ExpertCreateVM model)
        {
            var file = _fileService.UniqueFileName(model.Image.FileName);
            var path = _fileService.CreatePath("assets/img", file);
            await _fileService.UploadAsync(model.Image, path);

            Expert expert = new Expert { Image = file, Name = model.Name, Profession = model.Profession };
            await _context.Experts.AddAsync(expert);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var expert = await _context.Experts.FindAsync(id);
            string existingPath = _fileService.CreatePath("assets/img", expert.Image);
            _fileService.Delete(existingPath);
            _context.Experts.Remove(expert);

            await _context.SaveChangesAsync();
        }

        public  async Task<IEnumerable<ExpertVM>> GetAllAdminAsync()
        {
            var experts = await _context.Experts.Select(x => new ExpertVM { ID= x.ID, Image = x.Image, Name = x.Name, Profession = x.Profession }).ToListAsync();
            return experts;
        }

        public async Task<IEnumerable<ExpertUIVM>> GetAllAsync()
        {
            var experts = await _context.Experts.Select(x => new ExpertUIVM { Image = x.Image, Name = x.Name, Profession = x.Profession}).ToListAsync();
            return experts;
        }

        public async Task<ExpertDetailVM> GetByIDAsync(int id)
        {
            var expert = await _context.Experts.FindAsync(id);
            return new ExpertDetailVM { ID = expert.ID, Image = expert.Image, Name = expert.Name, Profession = expert.Profession }; 
        }

        public async Task UpdateAsync(int id, ExpertUpdateVM model)
        {
            var expert = await _context.Experts.FindAsync(id);

            if (model.NewImage != null)
            {
                var existingPath = _fileService.CreatePath("assets/img", expert.Image);
                _fileService.Delete(existingPath);
                var file = _fileService.UniqueFileName(model.NewImage.FileName);
                var path = _fileService.CreatePath("assets/img", file);
                await _fileService.UploadAsync(model.NewImage, path);
                expert.Image = file;
            }

            expert.Name = model.Name;
            expert.Profession = model.Profession;
            await _context.SaveChangesAsync();
        }
    }
}
