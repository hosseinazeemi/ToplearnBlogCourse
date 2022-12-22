using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Toplearn_Blog.Application.Interfaces;
using Toplearn_Blog.Domain.Entities;
using Toplearn_Blog.Shared.Dto.Category;
using Toplearn_Blog.Shared.Dto.Global;

namespace Toplearn_Blog.WebAPI.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryApiController
    {
        private readonly IMapper _autoMapper;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryApiController(IMapper mapper , ICategoryRepository categoryRepository)
        {
            _autoMapper = mapper;
            _categoryRepository = categoryRepository;
        }
        [HttpPost("create")]
        public async Task<ResponseDto<bool>> Create(CategoryDto category)
        {
            Category model = _autoMapper.Map<CategoryDto, Category>(category);
            try
            {
                int result = await _categoryRepository.Create(model);
                return new ResponseDto<bool>(true, "موفقیت آمیز", true);
            }
            catch (Exception e)
            {
                return new ResponseDto<bool>(false, e.Message, false);
                throw;
            }
        }

        [HttpGet("list")]
        public ResponseDto<List<CategoryDto>> List([FromQuery] Paginate paginate)
        {
            var result = _categoryRepository.GetAll(paginate).GetAwaiter().GetResult();

            // map
            var mapData = _autoMapper.Map<List<Category>, List<CategoryDto>>(result.Data);
            return new ResponseDto<List<CategoryDto>>(true, "دریافت شد", mapData, result.Paginate);
        }

        [HttpPost("remove")]
        public ResponseDto<bool> Remove([FromBody] int id)
        {
            var result = _categoryRepository.Remove(id).GetAwaiter().GetResult();
            return new ResponseDto<bool>(true, "موفقیت آمیز", result);
        }

        [HttpGet("find")]
        public ResponseDto<CategoryDto> Find([FromQuery] int id)
        {
            var result = _categoryRepository.FindById(id).GetAwaiter().GetResult();
            var mapData = _autoMapper.Map<Category, CategoryDto>(result);
            return new ResponseDto<CategoryDto>(true, "موفقیت آمیز", mapData);
        }

        [HttpPost("update")]
        public ResponseDto<bool> Update([FromBody] CategoryDto category)
        {
            var mapData = _autoMapper.Map<CategoryDto, Category>(category);
            var result = _categoryRepository.Update(mapData).GetAwaiter().GetResult();
            return new ResponseDto<bool>(true, "موفقیت آمیز", result);
        }
    }
}
