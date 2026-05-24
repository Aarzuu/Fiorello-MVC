using Fiorello_Web.Data;
using Fiorello_Web.Models;
using Fiorello_Web.Services.Interfaces;
using Fiorello_Web.ViewModels.Slider;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_Web.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;
        private readonly IFileService _fileService;
        public SliderService(AppDbContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task CreateAsync(SliderCreateVM model)
        {
            var file = _fileService.UniqueFileName(model.Image.FileName);
            var path = _fileService.CreatePath("assets/img", file);
            await _fileService.UploadAsync(model.Image, path);

            Slider slider = new Slider { Image = file };
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            string existingPath = _fileService.CreatePath("assets/img", slider.Image);
            _fileService.Delete(existingPath);
            _context.Sliders.Remove(slider);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SliderVM>> GetAllAdminAsync()
        {
            var sliders = await _context.Sliders.Select(x => new SliderVM { ID = x.ID, Image = x.Image}).ToListAsync();
            return sliders;
        }

        public async Task<IEnumerable<Slider>> GetAllAsync()
        {
            return await _context.Sliders.ToListAsync();
        }

        public async Task<SliderDetailVM> GetByIDAsync(int id)
        {
            var slider = await _context.Sliders.FindAsync(id);
            return new SliderDetailVM { ID = slider.ID, Image = slider.Image };

        }

        public async Task UpdateAsync(int? id, SliderUpdateVM? model)
        {
            var slider = await _context.Sliders.FindAsync(id);
            string existingPath = _fileService.CreatePath("assets/img", slider.Image);
            _fileService.Delete(existingPath);

            var file = _fileService.UniqueFileName(model.NewImage.FileName);
            var path = _fileService.CreatePath("assets/img", file);
            await _fileService.UploadAsync(model.NewImage, path);
            slider.Image = file;
            await _context.SaveChangesAsync();
        }
    }
}
