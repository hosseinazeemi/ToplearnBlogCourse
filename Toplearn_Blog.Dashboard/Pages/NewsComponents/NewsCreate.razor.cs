using AntDesign;
using Microsoft.AspNetCore.Components;
using Toplearn_Blog.Dashboard.Repositories.Admin;
using Toplearn_Blog.Dashboard.Repositories.Category;
using Toplearn_Blog.Dashboard.Repositories.News;
using Toplearn_Blog.Dashboard.Repositories.Tag;
using Toplearn_Blog.Shared.Dto.Category;
using Toplearn_Blog.Shared.Dto.News;
using Toplearn_Blog.Shared.Dto.Tag;
using Toplearn_Blog.Shared.Dto.User;

namespace Toplearn_Blog.Dashboard.Pages.NewsComponents
{
    public partial class NewsCreate
    {
        public bool Loading { get; set; }
        public NewsDto News { get; set; }
        [Inject]
        private INewsRepoService _repo { get; set; }
        [Inject]
        NotificationService _notice { get; set; }
        [Inject]
        private ICateogoryRepoService _categoryRepo { get; set; }
        [Inject]
        private IAdminRepoService _adminRepo { get; set; }
        [Inject]
        private ITagRepoService _tagRepo { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public List<UserDto> Users { get; set; }
        public List<TagDto> Tags { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Loading = true;
            News = new NewsDto();
            await GetCategories();
            await GetAdmins();
            await GetTags();
            Loading = false;
        }
        public async Task GetAdmins()
        {
            var result = await _adminRepo.GetAll();
            if (result.Status)
            {
                Users = result.Data;
            }
            else
            {
                Users = new List<UserDto>();
            }
        }
        public async Task GetCategories()
        {
            var result = await _categoryRepo.GetAll();
            if (result.Status)
            {
                Categories = result.Data;
            }
            else
            {
                Categories = new List<CategoryDto>();
            }
        }
        public async Task GetTags()
        {
            var result = await _tagRepo.GetAll();
            if (result.Status)
            {
                Tags = result.Data;
            }
            else
            {
                Tags = new List<TagDto>();
            }
        }
        public async Task Submit()
        {
            Loading = true;
            var result = await _repo.Create(News);
            if (result.Status)
            {
                await _notice.Open(new NotificationConfig()
                {
                    Message = "موفقیت آمیز",
                    Description = result.Message,
                    NotificationType = NotificationType.Success
                });
            }
            else
            {
                await _notice.Open(new NotificationConfig()
                {
                    Message = "خطا",
                    Description = result.Message,
                    NotificationType = NotificationType.Error
                });
            }
            Loading = false;
            StateHasChanged();
        }
    }
}
