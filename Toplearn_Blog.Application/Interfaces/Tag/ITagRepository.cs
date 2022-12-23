using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toplearn_Blog.Domain.Entities;
using Toplearn_Blog.Shared.Dto.Global;

namespace Toplearn_Blog.Application.Interfaces
{
    public interface ITagRepository
    {
        Task<int> Create(Tag model);
        Task<Tag> FindById(int id);
        Task<RepoResultDto<List<Tag>>> GetAll(Paginate paginate);
        Task<bool> Remove(int id);
        Task<bool> Update(Tag tag);
    }
}
