using Newtonsoft.Json;
using System.Text;
using Toplearn_Blog.Shared.Dto.Global;

namespace Toplearn_Blog.Dashboard.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _http;
        public HttpService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ResponseDto<TResult>> Get<TResult>(string url)
        {
            var response = await _http.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var deserialize = JsonConvert.DeserializeObject<ResponseDto<TResult>>(result);
                return await Task.FromResult(deserialize);
            }else
            {
                return new ResponseDto<TResult>(false, "خطا", default);
            }
        }

        public async Task<ResponseDto<TResult>> Post<TResult, TData>(string url, TData data)
        {
            var serializeData = JsonConvert.SerializeObject(data);

            var stringContent = new StringContent(serializeData , Encoding.UTF8 , "application/json");

            var response = await _http.PostAsync(url , stringContent);
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                var finaly = JsonConvert.DeserializeObject<ResponseDto<TResult>>(result);
                return await Task.FromResult(finaly);
            }
            else
            {
                return new ResponseDto<TResult>(false, "خطا", default);
            }
        }
    }
}
