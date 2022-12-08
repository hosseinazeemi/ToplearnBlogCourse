using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Toplearn_Blog.Application.Interfaces.Admin;
using Toplearn_Blog.Domain.Entities;
using Toplearn_Blog.Shared.Dto.User;
using Toplearn_Blog.Shared.Utilities;

namespace Toplearn_Blog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController
    {
        private readonly IMapper _autoMapper;
        private readonly IAdminRepository _adminRepository;
        public UserApiController(IMapper autoMapper , IAdminRepository adminRepository)
        {
            _autoMapper = autoMapper;
            _adminRepository = adminRepository;
        }

        [HttpPost("create")]
        public async Task<bool> Create(UserDto user)
        {
            User model = _autoMapper.Map<UserDto, User>(user);
            model.Password = HashPassword.Hash(user.Password);

            return await _adminRepository.Create(model);
        }
    }
}
