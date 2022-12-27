using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toplearn_Blog.Application.Interfaces;
using Toplearn_Blog.Application.Interfaces.Context;
using Toplearn_Blog.Domain.Entities;
using Toplearn_Blog.Shared.Dto.Global;

namespace Toplearn_Blog.Application.Services
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly IDatabaseContext _context;
        public CategoryRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Category model)
        {
            _context.Categories.Add(model);

            try
            {
                //_context.SaveChangesAsync();
                await _context.SaveChangesAsync();
                return model.Id;
            }
            catch (Exception)
            {
                return await Task.FromResult(0);
            }
        }

        public async Task<RepoResultDto<List<Category>>> List(Paginate paginate)
        {
            var queryable = _context.Categories.AsQueryable();
            var pageInfo = new Paginate(paginate.CurrentPage, paginate.Take, queryable.Count());
            var data = queryable.Select(item => new Category
            {
                Id = item.Id,
                Name = item.Name
            }).Skip(pageInfo.Skip).Take(pageInfo.Take).ToList();

            var result = new RepoResultDto<List<Category>>
            {
                Paginate = pageInfo,
                Data = data
            };
            return await Task.FromResult(result);
        }
        public async Task<List<Category>> GetAll()
        {
            var queryable = _context.Categories.AsQueryable();
            var data = queryable.Select(item => new Category
            {
                Id = item.Id,
                Name = item.Name
            }).ToList();

            return await Task.FromResult(data);
        }
        public async Task<bool> Remove(int id)
        {
            Category category = new Category
            {
                Id = id
            };
            _context.Categories.Remove(category);

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

        public async Task<Category> FindById(int id)
        {
            var result = _context.Categories.Where(p => p.Id == id).FirstOrDefault();

            return await Task.FromResult(result);
        }

        public async Task<bool> Update(Category category)
        {
            _context.Categories.Update(category);

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
