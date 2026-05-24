namespace Fiorello_Web.Services.Interfaces
{
    public interface IFileService
    {
        string UniqueFileName(string file);
        string CreatePath(string folder, string file);

        Task UploadAsync(IFormFile file, string path);
        void Delete(string path);
    }
}
