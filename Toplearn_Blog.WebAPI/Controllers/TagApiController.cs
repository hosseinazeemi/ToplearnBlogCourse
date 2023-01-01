using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Toplearn_Blog.Application.Interfaces;
using Toplearn_Blog.Domain.Entities;
using Toplearn_Blog.Shared.Dto.Global;
using Toplearn_Blog.Shared.Dto.Tag;

namespace Toplearn_Blog.WebAPI.Controllers
{
    [Route("api/tags")]
    [ApiController]
    public class TagApiController
    {
        private readonly IMapper _autoMapper;
        private readonly ITagRepository _tagRepository;
        public TagApiController(IMapper mapper, ITagRepository tagRepository)
        {
            _autoMapper = mapper;
            _tagRepository = tagRepository;
        }
        [HttpPost("create")]
        public async Task<ResponseDto<bool>> Create(TagDto tag)
        {
            Tag model = _autoMapper.Map<TagDto, Tag>(tag);
            try
            {
                int result = await _tagRepository.Create(model);
                return new ResponseDto<bool>(true, "موفقیت آمیز", true);
            }
            catch (Exception e)
            {
                return new ResponseDto<bool>(false, e.Message, false);
                throw;
            }
        }

        [HttpGet("list")]
        public ResponseDto<List<TagDto>> List([FromQuery] Paginate paginate)
        {
            var result = _tagRepository.GetAll(paginate).GetAwaiter().GetResult();

            // map
            var mapData = _autoMapper.Map<List<Tag>, List<TagDto>>(result.Data);
            return new ResponseDto<List<TagDto>>(true, "دریافت شد", mapData, result.Paginate);
        }
        [HttpGet("getAll")]
        public ResponseDto<List<TagDto>> GetAll()
        {
            var result = _tagRepository.GetAll().GetAwaiter().GetResult();

            // map
            var mapData = _autoMapper.Map<List<Tag>, List<TagDto>>(result);
            return new ResponseDto<List<TagDto>>(true, "دریافت شد", mapData);
        }

        [HttpPost("remove")]
        public ResponseDto<bool> Remove([FromBody] int id)
        {
            var result = _tagRepository.Remove(id).GetAwaiter().GetResult();
            return new ResponseDto<bool>(true, "موفقیت آمیز", result);
        }

        [HttpGet("find")]
        public ResponseDto<TagDto> Find([FromQuery] int id)
        {
            var result = _tagRepository.FindById(id).GetAwaiter().GetResult();
            var mapData = _autoMapper.Map<Tag, TagDto>(result);
            return new ResponseDto<TagDto>(true, "موفقیت آمیز", mapData);
        }

        [HttpPost("update")]
        public ResponseDto<bool> Update([FromBody] TagDto tag)
        {
            var mapData = _autoMapper.Map<TagDto, Tag>(tag);
            var result = _tagRepository.Update(mapData).GetAwaiter().GetResult();
            return new ResponseDto<bool>(true, "موفقیت آمیز", result);
        }
    }
}
