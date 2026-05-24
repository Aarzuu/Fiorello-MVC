using Fiorello_Web.Services.Interfaces;

namespace Fiorello_Web.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;
        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public string CreatePath(string folder, string file)
        {
            return Path.Combine(_environment.WebRootPath,folder,file);
        }

        public void Delete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public string UniqueFileName(string file)
        {
            return Guid.NewGuid().ToString() + "_" + file;
        }

        public async Task UploadAsync(IFormFile file, string path)
        {
            using FileStream fileStream = new(path, FileMode.Create);

            await file.CopyToAsync(fileStream);
        }
    }
}
