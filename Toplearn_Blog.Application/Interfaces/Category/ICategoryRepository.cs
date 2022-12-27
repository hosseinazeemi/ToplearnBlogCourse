using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toplearn_Blog.Domain.Entities;
using Toplearn_Blog.Shared.Dto.Global;

namespace Toplearn_Blog.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<int> Create(Category category);
        Task<Category> FindById(int id);
        Task<List<Category>> GetAll();
        Task<RepoResultDto<List<Category>>> List(Paginate paginate);
        Task<bool> Remove(int Id);
        Task<bool> Update(Category category);
    }
}
