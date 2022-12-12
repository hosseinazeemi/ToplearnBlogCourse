using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Toplearn_Blog.Application.Interfaces.Admin;
using Toplearn_Blog.Domain.Entities;
using Toplearn_Blog.Shared.Dto.Global;
using Toplearn_Blog.Shared.Dto.User;
using Toplearn_Blog.Shared.Utilities;

namespace Toplearn_Blog.WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserApiController
    {
        private readonly IMapper _autoMapper;
        private readonly IAdminRepository _adminRepository;
        public UserApiController(IMapper autoMapper, IAdminRepository adminRepository)
        {
            _autoMapper = autoMapper;
            _adminRepository = adminRepository;
        }

        [HttpPost("create")]
        public async Task<ResponseDto<bool>> Create(UserDto user)
        {
            User model = _autoMapper.Map<UserDto, User>(user);
            model.Password = HashPassword.Hash(user.Password);
            try
            {
                bool result = await _adminRepository.Create(model);
                return new ResponseDto<bool>(true, "موفقیت آمیز", result);
            }
            catch (Exception e)
            {
                return new ResponseDto<bool>(false, e.Message, false);
                throw;
            }
        }

        [HttpGet("list")]
        public ResponseDto<List<UserDto>> List([FromQuery]Paginate paginate)
        {
            var result = _adminRepository.GetAll(paginate).GetAwaiter().GetResult();

            // map
            var mapData = _autoMapper.Map<List<User>, List<UserDto>>(result.Data);
            return new ResponseDto<List<UserDto>>(true , "دریافت شد" , mapData , result.Paginate);
        }

        [HttpPost("remove")]
        public ResponseDto<bool> Remove([FromBody]int id)
        {
            var result = _adminRepository.Remove(id).GetAwaiter().GetResult();

            return new ResponseDto<bool>(true , "موفقیت آمیز" , result);
        }

        [HttpGet("find")]
        public ResponseDto<UserDto> Find([FromQuery]int id)
        {
            var result = _adminRepository.FindById(id).GetAwaiter().GetResult();
            var mapData = _autoMapper.Map<User, UserDto>(result);
            return new ResponseDto<UserDto>(true, "موفقیت آمیز", mapData);
        }

        [HttpPost("update")]
        public ResponseDto<bool> Update([FromBody]UserDto user)
        {
            var mapData = _autoMapper.Map<UserDto, User>(user);
            var result = _adminRepository.Update(mapData).GetAwaiter().GetResult();
            return new ResponseDto<bool>(true , "موفقیت آمیز" , result);
        }
    }
}
