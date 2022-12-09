using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toplearn_Blog.Application.Interfaces.Admin;
using Toplearn_Blog.Application.Interfaces.Context;
using Toplearn_Blog.Domain.Entities;
using Toplearn_Blog.Shared.Dto.User;
using Toplearn_Blog.Shared.Utilities;

namespace Toplearn_Blog.Application.Services.Admin
{
    public class AdminRepository : IAdminRepository
    {
        private readonly IDatabaseContext _context;
        public AdminRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public Task<bool> Create(User model)
        {
            _context.Users.Add(model);
           
            try
            {
                //_context.SaveChangesAsync();
                _context.SaveChangesAsync().GetAwaiter().GetResult();
                return Task.FromResult(true);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
        }

        public async Task<List<User>> GetAll()
        {
            var result = _context.Users.Select(item => new User
            {
                Id = item.Id,
                Name = item.Name , 
                LastName = item.LastName , 
                Phone = item.Phone,
                Email = item.Email , 
                IsActive = item.IsActive
            }).ToList();
            return await Task.FromResult(result);
        }
    }
}
