using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Toplearn_Blog.Application.Interfaces;
using Toplearn_Blog.Application.Interfaces.Admin;
using Toplearn_Blog.Domain.Entities;
using Toplearn_Blog.Shared.Dto.Global;
using Toplearn_Blog.Shared.Dto.Media;
using Toplearn_Blog.Shared.Dto.User;
using Toplearn_Blog.Shared.Utilities;
using Toplearn_Blog.WebAPI.Service;

namespace Toplearn_Blog.WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserApiController
    {
        private readonly IMapper _autoMapper;
        private readonly IAdminRepository _adminRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IFileService _fileService;
        public UserApiController(IMapper autoMapper, IAdminRepository adminRepository, IFileService fileService, IMediaRepository mediaRepository)
        {
            _autoMapper = autoMapper;
            _adminRepository = adminRepository;
            _fileService = fileService;
            _mediaRepository = mediaRepository;
        }

        [HttpPost("create")]
        public async Task<ResponseDto<bool>> Create(UserDto user)
        {
            User model = _autoMapper.Map<UserDto, User>(user);
            model.Password = HashPassword.Hash(user.Password);
            try
            {
                int result = await _adminRepository.Create(model);
                if (result > 0 && user.Files != null && user.Files.Count > 0)
                {
                    _fileService.Save(user.Files, nameof(User));

                    List<Media> userFiles = new List<Media>();
                    foreach (var item in user.Files)
                    {
                        userFiles.Add(new Media
                        {
                            Name = item.Name,
                            Extension = item.Extension,
                            TableName = nameof(User),
                            TableField = "File",
                            TableRowId = result
                        });
                    }

                    await _mediaRepository.Create(userFiles);
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
        public ResponseDto<List<UserDto>> List([FromQuery] Paginate paginate)
        {
            var result = _adminRepository.GetAll(paginate).GetAwaiter().GetResult();

            // map
            var mapData = _autoMapper.Map<List<User>, List<UserDto>>(result.Data);
            return new ResponseDto<List<UserDto>>(true, "دریافت شد", mapData, result.Paginate);
        }
        [HttpGet("getAll")]
        public ResponseDto<List<UserDto>> GetAll()
        {
            var result = _adminRepository.GetAll().GetAwaiter().GetResult();

            // map
            var mapData = _autoMapper.Map<List<User>, List<UserDto>>(result);
            return new ResponseDto<List<UserDto>>(true, "دریافت شد", mapData);
        }
        [HttpPost("remove")]
        public ResponseDto<bool> Remove([FromBody] int id)
        {
            var result = _adminRepository.Remove(id).GetAwaiter().GetResult();

            if (result)
            {
                List<Media> media = _mediaRepository.Remove(id, nameof(User)).GetAwaiter().GetResult();
                var mapData = _autoMapper.Map<List<Media>, List<MapMediaDto>>(media);
                _fileService.Delete(mapData);
            }
            return new ResponseDto<bool>(true, "موفقیت آمیز", result);
        }

        [HttpGet("find")]
        public ResponseDto<UserDto> Find([FromQuery] int id)
        {
            var result = _adminRepository.FindById(id).GetAwaiter().GetResult();
            var mapData = _autoMapper.Map<User, UserDto>(result);
            return new ResponseDto<UserDto>(true, "موفقیت آمیز", mapData);
        }

        [HttpPost("update")]
        public ResponseDto<bool> Update([FromBody] UserDto user)
        {
            var mapData = _autoMapper.Map<UserDto, User>(user);
            var result = _adminRepository.Update(mapData).GetAwaiter().GetResult();
            return new ResponseDto<bool>(true, "موفقیت آمیز", result);
        }
        [HttpPost("changeState")]
        public ResponseDto<bool> ChangeState([FromBody] int id)
        {
            var result = _adminRepository.ChangeState(id).GetAwaiter().GetResult();
            return new ResponseDto<bool>(true, "موفقیت آمیز", result);
        }
    }
}
