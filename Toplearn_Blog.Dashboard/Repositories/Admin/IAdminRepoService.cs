using Toplearn_Blog.Shared.Dto.Global;
using Toplearn_Blog.Shared.Dto.User;

namespace Toplearn_Blog.Dashboard.Repositories.Admin
{
    public interface IAdminRepoService
    {
        Task<ResponseDto<bool>> Create(UserDto user);
        Task<ResponseDto<List<UserDto>>> GetAll(Paginate paginate);
        Task<ResponseDto<bool>> Remove(int Id);
    }
}
