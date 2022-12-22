using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toplearn_Blog.Application.Interfaces;
using Toplearn_Blog.Application.Interfaces.Context;
using Toplearn_Blog.Domain.Entities;

namespace Toplearn_Blog.Application.Services
{
    public class MediaRepository : IMediaRepository
    {
        private readonly IDatabaseContext _context;
        public MediaRepository(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(List<Media> files)
        {
            await _context.Media.AddRangeAsync(files);

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

        public async Task<bool> Create(Media file)
        {
            await _context.Media.AddAsync(file);

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

        public async Task<List<Media>> Remove(int id, string tableName)
        {
            var allMedia = _context.Media.Where(p => p.TableRowId == id && p.TableName == tableName).ToList();

            _context.Media.RemoveRange(allMedia);

            try
            {
                await _context.SaveChangesAsync();
                return allMedia;
            }
            catch (Exception)
            {
                return new List<Media>();
                throw;
            }
        }
    }
}
