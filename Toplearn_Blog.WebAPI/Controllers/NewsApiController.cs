using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Toplearn_Blog.Application.Interfaces;
using Toplearn_Blog.Domain.Entities;
using Toplearn_Blog.Shared.Dto.Global;
using Toplearn_Blog.Shared.Dto.Media;
using Toplearn_Blog.Shared.Dto.News;
using Toplearn_Blog.WebAPI.Service;

namespace Toplearn_Blog.WebAPI.Controllers
{
    [Route("api/news")]
    [ApiController]
    public class NewsApiController
    {
        private readonly IMapper _autoMapper;
        private readonly INewsRepository _newsRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IFileService _fileService;
        public NewsApiController(IMapper autoMapper, INewsRepository newsRepository, IFileService fileService, IMediaRepository mediaRepository)
        {
            _autoMapper = autoMapper;
            _newsRepository = newsRepository;
            _fileService = fileService;
            _mediaRepository = mediaRepository;
        }

        [HttpPost("create")]
        public async Task<ResponseDto<bool>> Create(NewsDto news)
        {
            News model = _autoMapper.Map<NewsDto, News>(news);
            try
            {
                int result = await _newsRepository.Create(model);
                if (result > 0 && news.Files != null && news.Files.Count > 0)
                {
                    _fileService.Save(news.Files, nameof(News));

                    List<Media> newsFiles = new List<Media>();
                    foreach (var item in news.Files)
                    {
                        newsFiles.Add(new Media
                        {
                            Name = item.Name,
                            Extension = item.Extension,
                            TableName = nameof(News),
                            TableField = "File",
                            TableRowId = result
                        });
                    }

                    await _mediaRepository.Create(newsFiles);
                }
                return new ResponseDto<bool>(true, "موفقیت آمیز", true);
            }
            catch (Exception e)
            {
                return new ResponseDto<bool>(false, e.Message, false);
                throw;
            }
        }

        [HttpGet("list")]
        public ResponseDto<List<NewsDto>> List([FromQuery] Paginate paginate)
        {
            var result = _newsRepository.GetAll(paginate).GetAwaiter().GetResult();

            // map
            var mapData = _autoMapper.Map<List<News>, List<NewsDto>>(result.Data);
            return new ResponseDto<List<NewsDto>>(true, "دریافت شد", mapData, result.Paginate);
        }
        [HttpGet("getAll")]
        public ResponseDto<List<NewsDto>> GetAll()
        {
            var result = _newsRepository.GetAll().GetAwaiter().GetResult();

            // map
            var mapData = _autoMapper.Map<List<News>, List<NewsDto>>(result);
            return new ResponseDto<List<NewsDto>>(true, "دریافت شد", mapData);
        }
        [HttpPost("remove")]
        public ResponseDto<bool> Remove([FromBody] int id)
        {
            var result = _newsRepository.Remove(id).GetAwaiter().GetResult();

            if (result)
            {
                List<Media> media = _mediaRepository.Remove(id, nameof(News)).GetAwaiter().GetResult();
                var mapData = _autoMapper.Map<List<Media>, List<MapMediaDto>>(media);
                _fileService.Delete(mapData);
            }
            return new ResponseDto<bool>(true, "موفقیت آمیز", result);
        }

        [HttpGet("find")]
        public ResponseDto<NewsDto> Find([FromQuery] int id)
        {
            var result = _newsRepository.FindById(id).GetAwaiter().GetResult();
            result.Media = _mediaRepository.Get(id , nameof(News)).GetAwaiter().GetResult();
            var mapData = _autoMapper.Map<News, NewsDto>(result);
            return new ResponseDto<NewsDto>(true, "موفقیت آمیز", mapData);
        }

        [HttpPost("update")]
        public ResponseDto<bool> Update([FromBody] NewsDto news)
        {
            var mapData = _autoMapper.Map<NewsDto, News>(news);
            var result = _newsRepository.Update(mapData).GetAwaiter().GetResult();
            return new ResponseDto<bool>(true, "موفقیت آمیز", result);
        }
        [HttpPost("changeState")]
        public ResponseDto<bool> ChangeState([FromBody] int id)
        {
            var result = _newsRepository.ChangeState(id).GetAwaiter().GetResult();
            return new ResponseDto<bool>(true, "موفقیت آمیز", result);
        }
        [HttpPost("changeSelected")]
        public ResponseDto<bool> ChangeSelected([FromBody] int id)
        {
            var result = _newsRepository.ChangeSelected(id).GetAwaiter().GetResult();
            return new ResponseDto<bool>(true, "موفقیت آمیز", result);
        }
        [HttpPost("changePopular")]
        public ResponseDto<bool> ChangePopular([FromBody] int id)
        {
            var result = _newsRepository.ChangePopular(id).GetAwaiter().GetResult();
            return new ResponseDto<bool>(true, "موفقیت آمیز", result);
        }
        [HttpPost("changeSuggest")]
        public ResponseDto<bool> ChangeSuggest([FromBody] int id)
        {
            var result = _newsRepository.ChangeSuggest(id).GetAwaiter().GetResult();
            return new ResponseDto<bool>(true, "موفقیت آمیز", result);
        }
    }
}
