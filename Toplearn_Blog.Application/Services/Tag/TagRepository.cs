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
    public class TagRepository:ITagRepository
    {
        private readonly IDatabaseContext _context;
        public TagRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Tag model)
        {
            _context.Tags.Add(model);

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

        public async Task<RepoResultDto<List<Tag>>> GetAll(Paginate paginate)
        {
            var queryable = _context.Tags.AsQueryable();
            var pageInfo = new Paginate(paginate.CurrentPage, paginate.Take, queryable.Count());
            var data = queryable.Select(item => new Tag
            {
                Id = item.Id,
                Name = item.Name
            }).Skip(pageInfo.Skip).Take(pageInfo.Take).ToList();

            var result = new RepoResultDto<List<Tag>>
            {
                Paginate = pageInfo,
                Data = data
            };
            return await Task.FromResult(result);
        }

        public async Task<List<Tag>> GetAll()
        {
            var data = _context.Tags.Select(item => new Tag
            {
                Id = item.Id,
                Name = item.Name
            }).ToList();

            return await Task.FromResult(data);
        }

        public async Task<bool> Remove(int id)
        {
            Tag tag = new Tag
            {
                Id = id
            };
            _context.Tags.Remove(tag);

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

        public async Task<Tag> FindById(int id)
        {
            var result = _context.Tags.Where(p => p.Id == id).FirstOrDefault();

            return await Task.FromResult(result);
        }

        public async Task<bool> Update(Tag tag)
        {
            _context.Tags.Update(tag);

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
