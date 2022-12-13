using Toplearn_Blog.Dashboard.Services;
using Toplearn_Blog.Shared.Dto.Global;
using Toplearn_Blog.Shared.Dto.User;

namespace Toplearn_Blog.Dashboard.Repositories.Admin
{
    public class AdminRepoService : IAdminRepoService
    {
        private readonly IHttpService _http;
        private const string baseUrl = "/api/users";
        public AdminRepoService(IHttpService http)
        {
            _http = http;
        }

        public Task<ResponseDto<bool>> Create(UserDto user)
        {
            return _http.Post<bool , UserDto>($"{baseUrl}/create", user);
        }

        public Task<ResponseDto<List<UserDto>>> GetAll(Paginate paginate)
        {
            return _http.Get<List<UserDto>>($"{baseUrl}/list?CurrentPage={paginate.CurrentPage}&Take={paginate.Take}");
        }

        public Task<ResponseDto<bool>> Remove(int Id)
        {
            return _http.Post<bool, int>($"{baseUrl}/remove" , Id);
        }

        public Task<ResponseDto<UserDto>> GetUserById(int id)
        {
            return _http.Get<UserDto>($"{baseUrl}/find?id={id}");
        }

        public Task<ResponseDto<bool>> Update(UserDto user)
        {
            return _http.Post<bool, UserDto>($"{baseUrl}/update" , user);
        }

        public Task<ResponseDto<bool>> ChangeState(int id)
        {
            return _http.Post<bool, int>($"{baseUrl}/changeState" , id);
        }
    }
}
