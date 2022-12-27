using Toplearn_Blog.Shared.Dto.Category;
using Toplearn_Blog.Shared.Dto.Global;

namespace Toplearn_Blog.Dashboard.Repositories.Category
{
    public interface ICateogoryRepoService
    {
        Task<ResponseDto<bool>> Create(CategoryDto category);
        Task<ResponseDto<List<CategoryDto>>> GetAll(Paginate paginate);
        Task<ResponseDto<List<CategoryDto>>> GetAll();
        Task<ResponseDto<CategoryDto>> GetCategoryById(int id);
        Task<ResponseDto<bool>> Remove(int id);
        Task<ResponseDto<bool>> Update(CategoryDto category);
    }
}
