using Toplearn_Blog.Shared.Dto.Global;
using Toplearn_Blog.Shared.Dto.User;

namespace Toplearn_Blog.Dashboard.Repositories.Admin
{
    public interface IAdminRepoService
    {
        Task<ResponseDto<bool>> Create(UserDto user);
        Task<ResponseDto<List<UserDto>>> GetAll(Paginate paginate);
        Task<ResponseDto<bool>> Remove(int id);
        Task<ResponseDto<UserDto>> GetUserById(int id);
        Task<ResponseDto<bool>> Update(UserDto user);
        Task<ResponseDto<bool>> ChangeState(int id);
        Task<ResponseDto<List<UserDto>>> GetAll();
    }
}
