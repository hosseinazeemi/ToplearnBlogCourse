﻿using Toplearn_Blog.Dashboard.Services;
using Toplearn_Blog.Shared.Dto.Global;
using Toplearn_Blog.Shared.Dto.User;

namespace Toplearn_Blog.Dashboard.Repositories.Admin
{
    public class AdminRepoService : IAdminRepoService
    {
        private readonly IHttpService _http;
        private const string baseUrl = "/api/users";
        public AdminRepoService(IHttpService http)
        {
            _http = http;
        }

        public Task<ResponseDto<bool>> Create(UserDto user)
        {
            return _http.Post<bool , UserDto>($"{baseUrl}/create", user);
        }
    }
}