using Toplearn_Blog.Shared.Dto.Global;
using Toplearn_Blog.Shared.Dto.News;

namespace Toplearn_Blog.Dashboard.Repositories.News
{
    public interface INewsRepoService
    {
        Task<ResponseDto<bool>> ChangePuplar(int id);
        Task<ResponseDto<bool>> ChangeSelected(int id);
        Task<ResponseDto<bool>> ChangeState(int id);
        Task<ResponseDto<bool>> ChangeSuggest(int id);
        Task<ResponseDto<bool>> Create(NewsDto news);
        Task<ResponseDto<List<NewsDto>>> GetAll(Paginate paginate);
        Task<ResponseDto<NewsDto>> GetNewsById(int id);
        Task<ResponseDto<bool>> Remove(int id);
        Task<ResponseDto<bool>> Update(NewsDto news);
    }
}
