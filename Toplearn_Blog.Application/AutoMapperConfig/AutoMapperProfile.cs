using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toplearn_Blog.Domain.Entities;
using Toplearn_Blog.Shared.Dto.Category;
using Toplearn_Blog.Shared.Dto.Media;
using Toplearn_Blog.Shared.Dto.News;
using Toplearn_Blog.Shared.Dto.Tag;
using Toplearn_Blog.Shared.Dto.User;

namespace Toplearn_Blog.Application.AutoMapperConfig
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<Media, MapMediaDto>();
            CreateMap<MapMediaDto, Media>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto , Category>();
            CreateMap<TagDto , Tag>();
            CreateMap<Tag , TagDto>();
            CreateMap<NewsDto , News>().ForMember(p => p.Media , x => x.MapFrom(y => y.ShowFiles));
            CreateMap<News , NewsDto>().ForMember(p => p.ShowFiles, x => x.MapFrom(y => y.Media));
        }
    }
}
