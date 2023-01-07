using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toplearn_Blog.Domain.Entities;

namespace Toplearn_Blog.Application.Interfaces
{
    public interface IMediaRepository
    {
        Task<bool> Create(List<Media> files);
        Task<bool> Create(Media file);
        Task<List<Media>> Remove(int id , string tableName); 
        Task<List<Media>> Get(int id , string tableName); 
    }
}
