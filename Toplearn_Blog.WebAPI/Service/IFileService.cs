using Toplearn_Blog.Shared.Dto.Media;

namespace Toplearn_Blog.WebAPI.Service
{
    public interface IFileService
    {
        List<MediaDto> Save(List<MediaDto> files , string folderName);
        Task<string> Save(IFormFile file , string folderName);
        void Delete(List<MapMediaDto> files);
    }
}
