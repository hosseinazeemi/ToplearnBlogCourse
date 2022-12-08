using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toplearn_Blog.Domain.Entities;
using Toplearn_Blog.Shared.Dto.User;

namespace Toplearn_Blog.Application.Interfaces.Admin
{
    public interface IAdminRepository
    {
        Task<bool> Create(User user);
    }
}
