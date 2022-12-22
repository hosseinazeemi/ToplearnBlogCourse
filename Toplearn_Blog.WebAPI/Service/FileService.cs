using Toplearn_Blog.Shared.Dto.Media;
using Toplearn_Blog.WebAPI.Service;

namespace Toplearn_Blog.WebAPI.Helper
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _env;
        public FileService(IWebHostEnvironment env)
        {
            _env = env;
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
        public void Delete(List<DeleteMediaDto> files)
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

    }
}
