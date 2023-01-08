using Toplearn_Blog.Shared.Dto.Media;
using Toplearn_Blog.WebAPI.Service;

namespace Toplearn_Blog.WebAPI.Helper
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContext;
        public FileService(IWebHostEnvironment env, IHttpContextAccessor httpContext)
        {
            _env = env;
            _httpContext = httpContext;
        }
        public List<MediaDto> Save(List<MediaDto> files, string folderName)
        {
            foreach (var item in files)
            {
                string fileName = $"{Guid.NewGuid()}.{item.Extension}";
                string directory = Path.Combine(_env.WebRootPath, folderName);
                string path = Path.Combine(directory, fileName);

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                File.WriteAllBytesAsync(path, item.Bytes).GetAwaiter();

                item.Name = fileName;
            }

            return files;
        }
        public void Delete(List<MapMediaDto> files)
        {
            foreach (var item in files)
            {
                var current = Path.GetFileName(item.Name);
                string address = Path.Combine(_env.WebRootPath, item.TableName, current);

                if (File.Exists(address))
                {
                    File.Delete(address);
                }
            }
        }

        public async Task<string> Save(IFormFile file, string folderName)
        {
            string fileName = $"{Guid.NewGuid() + Path.GetExtension(file.FileName)}";
            string directory = Path.Combine(_env.WebRootPath, folderName);
            string path = Path.Combine(directory , fileName);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            if (file.Length > 0)
            {
                using (Stream fileStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }

            var fullUrl = $"{_httpContext.HttpContext.Request.Scheme}://{_httpContext.HttpContext.Request.Host}/{folderName}/{fileName}";

            return fullUrl;
        }
    }
}
