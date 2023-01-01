using Microsoft.EntityFrameworkCore;
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
    public class NewsRepository : INewsRepository
    {
        private readonly IDatabaseContext _context;
        public NewsRepository(IDatabaseContext context)
        {
            _context = context;
        }

        public async Task<int> Create(News model)
        {
            //_context.News.Add(model);
            _context.News.Attach(model);
            try
            {
                await _context.SaveChangesAsync();
                return model.Id;
            }
            catch (Exception)
            {
                return await Task.FromResult(0);
            }
        }

        public async Task<RepoResultDto<List<News>>> GetAll(Paginate paginate)
        {
            var queryable = _context.News.AsQueryable();
            var pageInfo = new Paginate(paginate.CurrentPage, paginate.Take, queryable.Count());
            var data = queryable.Select(item => new News
            {
                Id = item.Id,
                IsActive = item.IsActive
            }).Skip(pageInfo.Skip).Take(pageInfo.Take).ToList();

            var result = new RepoResultDto<List<News>>
            {
                Paginate = pageInfo,
                Data = data
            };
            return await Task.FromResult(result);
        }
        public async Task<List<News>> GetAll()
        {
            var queryable = _context.News.AsQueryable();
            var data = queryable.Select(item => new News
            {
                Id = item.Id,
                IsActive = item.IsActive
            }).ToList();

            return await Task.FromResult(data);
        }
        public async Task<bool> Remove(int id)
        {
            News news = new News
            {
                Id = id
            };
            _context.News.Remove(news);

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

        public async Task<News> FindById(int id)
        {
            var result = _context.News.Where(p => p.Id == id).FirstOrDefault();

            return await Task.FromResult(result);
        }

        public async Task<bool> Update(News news)
        {
            _context.News.Update(news);

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

        public async Task<bool> ChangeState(int id)
        {
            var news = await _context.News.FindAsync(id);

            try
            {
                if (news != null)
                {
                    news.IsActive = !news.IsActive;
                    _context.SaveChanges();
                    return true;
                }
                throw new ArgumentNullException(null, "News Model Is Null");
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> ChangePopular(int id)
        {
            var news = await _context.News.FindAsync(id);

            try
            {
                if (news != null)
                {
                    news.IsPopular = !news.IsPopular;
                    _context.SaveChanges();
                    return true;
                }
                throw new ArgumentNullException(null, "News Model Is Null");
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> ChangeSelected(int id)
        {
            var news = await _context.News.FindAsync(id);

            try
            {
                if (news != null)
                {
                    news.Selected = !news.Selected;
                    _context.SaveChanges();
                    return true;
                }
                throw new ArgumentNullException(null, "News Model Is Null");
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public async Task<bool> ChangeSuggest(int id)
        {
            var news = await _context.News.FindAsync(id);

            try
            {
                if (news != null)
                {
                    news.IsSuggest = !news.IsSuggest;
                    _context.SaveChanges();
                    return true;
                }
                throw new ArgumentNullException(null, "News Model Is Null");
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
