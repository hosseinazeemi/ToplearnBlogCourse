﻿using AutoMapper;
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
        public ResponseDto<List<UserDto>> List()
        {
            var result = _adminRepository.GetAll().GetAwaiter().GetResult();
            // map
            var mapData = _autoMapper.Map<List<User>, List<UserDto>>(result);
            return new ResponseDto<List<UserDto>>(true , "دریافت شد" , mapData);
        }
    }
}
