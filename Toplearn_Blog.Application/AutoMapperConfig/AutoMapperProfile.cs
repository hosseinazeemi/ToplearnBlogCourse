using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toplearn_Blog.Domain.Entities;
using Toplearn_Blog.Shared.Dto.Category;
using Toplearn_Blog.Shared.Dto.Media;
using Toplearn_Blog.Shared.Dto.User;

namespace Toplearn_Blog.Application.AutoMapperConfig
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<Media, DeleteMediaDto>();
            CreateMap<DeleteMediaDto, Media>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto , Category>();
        }
    }
}
