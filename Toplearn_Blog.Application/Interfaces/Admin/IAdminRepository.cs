using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toplearn_Blog.Domain.Entities;
using Toplearn_Blog.Shared.Dto.Global;
using Toplearn_Blog.Shared.Dto.User;

namespace Toplearn_Blog.Application.Interfaces.Admin
{
    public interface IAdminRepository
    {
        Task<bool> Create(User user);
        Task<User> FindById(int id);
        Task<RepoResultDto<List<User>>> GetAll(Paginate paginate);
        Task<bool> Remove(int Id);
        Task<bool> Update(User user);
    }
}
