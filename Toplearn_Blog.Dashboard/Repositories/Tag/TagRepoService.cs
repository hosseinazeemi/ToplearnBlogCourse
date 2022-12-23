using Toplearn_Blog.Dashboard.Services;
using Toplearn_Blog.Shared.Dto.Global;
using Toplearn_Blog.Shared.Dto.Tag;

namespace Toplearn_Blog.Dashboard.Repositories.Tag
{
    public class TagRepoService:ITagRepoService
    {
        private readonly IHttpService _http;
        private const string baseUrl = "/api/tags";
        public TagRepoService(IHttpService http)
        {
            _http = http;
        }

        public Task<ResponseDto<bool>> Create(TagDto tag)
        {
            return _http.Post<bool, TagDto>($"{baseUrl}/create", tag);
        }

        public Task<ResponseDto<List<TagDto>>> GetAll(Paginate paginate)
        {
            return _http.Get<List<TagDto>>($"{baseUrl}/list?CurrentPage={paginate.CurrentPage}&Take={paginate.Take}");
        }

        public Task<ResponseDto<bool>> Remove(int id)
        {
            return _http.Post<bool, int>($"{baseUrl}/remove", id);
        }


        public Task<ResponseDto<bool>> Update(TagDto tag)
        {
            return _http.Post<bool, TagDto>($"{baseUrl}/update", tag);
        }

        public Task<ResponseDto<TagDto>> GetTagById(int id)
        {
            return _http.Get<TagDto>($"{baseUrl}/find?id={id}");
        }
    }
}
