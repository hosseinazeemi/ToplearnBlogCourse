using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toplearn_Blog.Domain.Entities;
using Toplearn_Blog.Shared.Dto.Global;

namespace Toplearn_Blog.Application.Interfaces
{
    public interface INewsRepository
    {
        Task<int> Create(News news);
        Task<News> FindById(int id);
        Task<RepoResultDto<List<News>>> GetAll(Paginate paginate);
        Task<bool> Remove(int Id);
        Task<bool> Update(News news);
        Task<bool> ChangeState(int id);
        Task<bool> ChangePopular(int id);
        Task<bool> ChangeSelected(int id);
        Task<bool> ChangeSuggest(int id);
        Task<List<News>> GetAll();
    }
}
