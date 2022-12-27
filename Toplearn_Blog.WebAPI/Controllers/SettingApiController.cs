using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Toplearn_Blog.Domain.Entities;
using Toplearn_Blog.WebAPI.Service;

namespace Toplearn_Blog.WebAPI.Controllers
{
    [Route("api/setting")]
    [ApiController]
    public class SettingApiController
    {
        private readonly IFileService _fileService;
        public SettingApiController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("uploadImage")]
        public string UploadImage(IFormFile upload)
        {
            var result = _fileService.Save(upload, nameof(Media)).Result;

            return JsonConvert.SerializeObject(new
            {
                uploaded = true , 
                url = result
            });
        }
    }
}
