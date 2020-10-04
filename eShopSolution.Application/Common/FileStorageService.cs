using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
namespace eShopSolution.Application.Common
{
    public class FileStorageService: IStorageService
    {
        private readonly string _userContentFolder;
        private const string USER_CONTENT_FOLDER_NAME = "TNT";

        public FileStorageService(IWebHostEnvironment webHostEnviroment)
        {
            _userContentFolder = Path.Combine(webHostEnviroment.WebRootPath, USER_CONTENT_FOLDER_NAME);
            if (!Directory.Exists(_userContentFolder))
            {
                Directory.CreateDirectory(_userContentFolder);
            }
        }
        public async Task DeleteAsync(string fileName)
        {
            var filePath = Path.Combine(_userContentFolder, fileName);
            if (File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        public string GetFileUrl(string fileName)
        {
            return $"/{USER_CONTENT_FOLDER_NAME}/{fileName}";
        }

        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName)
        {
            var filePath = Path.Combine(_userContentFolder, fileName);
            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }
    }
}
