using Toplearn_Blog.Shared.Dto.Global;

namespace Toplearn_Blog.Dashboard.Services
{
    public interface IHttpService
    {
        Task<ResponseDto<TResult>> Post<TResult, TData>(string url , TData data);
        Task<ResponseDto<TResult>> Get<TResult>(string url);
    }
}
