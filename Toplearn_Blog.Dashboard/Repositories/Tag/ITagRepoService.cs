using Toplearn_Blog.Shared.Dto.Global;
using Toplearn_Blog.Shared.Dto.Tag;

namespace Toplearn_Blog.Dashboard.Repositories.Tag
{
    public interface ITagRepoService
    {
        Task<ResponseDto<bool>> Create(TagDto tag);
        Task<ResponseDto<List<TagDto>>> GetAll(Paginate paginate);
        Task<ResponseDto<TagDto>> GetTagById(int id);
        Task<ResponseDto<bool>> Remove(int id);
        Task<ResponseDto<bool>> Update(TagDto tag);
    }
}
