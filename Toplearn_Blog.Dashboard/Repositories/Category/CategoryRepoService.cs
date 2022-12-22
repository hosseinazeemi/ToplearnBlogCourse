using Toplearn_Blog.Dashboard.Services;
using Toplearn_Blog.Shared.Dto.Category;
using Toplearn_Blog.Shared.Dto.Global;

namespace Toplearn_Blog.Dashboard.Repositories.Category
{
    public class CategoryRepoService : ICateogoryRepoService
    {
        private readonly IHttpService _http;
        private const string baseUrl = "/api/categories";
        public CategoryRepoService(IHttpService http)
        {
            _http = http;
        }

        public Task<ResponseDto<bool>> Create(CategoryDto category)
        {
            return _http.Post<bool, CategoryDto>($"{baseUrl}/create", category);
        }

        public Task<ResponseDto<List<CategoryDto>>> GetAll(Paginate paginate)
        {
            return _http.Get<List<CategoryDto>>($"{baseUrl}/list?CurrentPage={paginate.CurrentPage}&Take={paginate.Take}");
        }

        public Task<ResponseDto<bool>> Remove(int id)
        {
            return _http.Post<bool, int>($"{baseUrl}/remove", id);
        }


        public Task<ResponseDto<bool>> Update(CategoryDto category)
        {
            return _http.Post<bool, CategoryDto>($"{baseUrl}/update", category);
        }

    }
}
