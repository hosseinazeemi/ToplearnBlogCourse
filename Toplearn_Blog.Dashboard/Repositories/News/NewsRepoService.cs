using Toplearn_Blog.Dashboard.Services;
using Toplearn_Blog.Shared.Dto.Global;
using Toplearn_Blog.Shared.Dto.News;

namespace Toplearn_Blog.Dashboard.Repositories.News
{
    public class NewsRepoService:INewsRepoService
    {
        private readonly IHttpService _http;
        private const string baseUrl = "/api/news";
        public NewsRepoService(IHttpService http)
        {
            _http = http;
        }

        public Task<ResponseDto<bool>> Create(NewsDto news)
        {
            return _http.Post<bool, NewsDto>($"{baseUrl}/create", news);
        }

        public Task<ResponseDto<List<NewsDto>>> GetAll(Paginate paginate)
        {
            return _http.Get<List<NewsDto>>($"{baseUrl}/list?CurrentPage={paginate.CurrentPage}&Take={paginate.Take}");
        }

        public Task<ResponseDto<bool>> Remove(int id)
        {
            return _http.Post<bool, int>($"{baseUrl}/remove", id);
        }

        public Task<ResponseDto<bool>> Update(NewsDto news)
        {
            return _http.Post<bool, NewsDto>($"{baseUrl}/update", news);
        }

        public Task<ResponseDto<NewsDto>> GetNewsById(int id)
        {
            return _http.Get<NewsDto>($"{baseUrl}/find?id={id}");
        }
        public Task<ResponseDto<bool>> ChangeState(int id)
        {
            return _http.Post<bool, int>($"{baseUrl}/changeState", id);
        }
        public Task<ResponseDto<bool>> ChangeSelected(int id)
        {
            return _http.Post<bool, int>($"{baseUrl}/changeSelected", id);
        }
        public Task<ResponseDto<bool>> ChangePopular(int id)
        {
            return _http.Post<bool, int>($"{baseUrl}/changePopular", id);
        }
        public Task<ResponseDto<bool>> ChangeSuggest(int id)
        {
            return _http.Post<bool, int>($"{baseUrl}/changeSuggest", id);
        }
    }
}
