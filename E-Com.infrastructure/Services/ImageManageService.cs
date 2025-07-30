using E_Com.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace E_Com.infrastructure.Services
{
    public class ImageManageService : IImageManageService
    {
        private readonly IFileProvider _fileProvider;
        public ImageManageService(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }
        public async Task<List<string>> AddImageAsync(List<IFormFile> Photo, string src)
        {
            var saveImage = new List<string>();

            // physical path
            var wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var folderName = string.IsNullOrWhiteSpace(src) ? Guid.NewGuid().ToString() : src;
            var imageDirectory = Path.Combine(wwwRootPath, "Images", folderName);

            if (!Directory.Exists(imageDirectory))
                Directory.CreateDirectory(imageDirectory);

            foreach (var item in Photo)
            {
                if (item.Length > 0)
                {
                    var imageName = item.FileName;
                    var imagePath = Path.Combine(imageDirectory, imageName);
                    var imageUrl = $"/Images/{folderName}/{imageName}";

                    using var stream = new FileStream(imagePath, FileMode.Create);
                    await item.CopyToAsync(stream);

                    saveImage.Add(imageUrl);
                }
            }
            return saveImage;
        }
        public void DeleteImageAsync(string src)
        {
            var info = _fileProvider.GetFileInfo(src);
            var root = info.PhysicalPath;

            if (File.Exists(root))
                File.Delete(root);
        }


    }
}
