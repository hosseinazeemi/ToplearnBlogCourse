using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toplearn_Blog.Application.Interfaces.Admin;
using Toplearn_Blog.Application.Interfaces.Context;
using Toplearn_Blog.Domain.Entities;
using Toplearn_Blog.Shared.Dto.Global;
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

        public async Task<RepoResultDto<List<User>>> GetAll(Paginate paginate)
        {
            var queryable = _context.Users.AsQueryable();
            var pageInfo = new Paginate(paginate.CurrentPage, paginate.Take, queryable.Count());
            var data = queryable.Select(item => new User
            {
                Id = item.Id,
                Name = item.Name,
                LastName = item.LastName,
                Phone = item.Phone,
                Email = item.Email,
                IsActive = item.IsActive
            }).Skip(pageInfo.Skip).Take(pageInfo.Take).ToList();

            var result = new RepoResultDto<List<User>>
            {
                Paginate = pageInfo,
                Data = data
            };
            return await Task.FromResult(result);
        }

        public async Task<bool> Remove(int id)
        {
            User user = new User
            {
                Id = id
            };
            _context.Users.Remove(user);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<User> FindById(int id)
        {
            var result = _context.Users.Where(p => p.Id == id).FirstOrDefault();

            return await Task.FromResult(result);
        }

        public async Task<bool> Update(User user)
        {
            _context.Users.Update(user);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
