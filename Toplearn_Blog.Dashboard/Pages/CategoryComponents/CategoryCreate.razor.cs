using AntDesign;
using Microsoft.AspNetCore.Components;
using Toplearn_Blog.Dashboard.Repositories.Category;
using Toplearn_Blog.Shared.Dto.Category;

namespace Toplearn_Blog.Dashboard.Pages.CategoryComponents
{
    public partial class CategoryCreate
    {
        public bool Loading { get; set; }
        public CategoryDto Category { get; set; }
        [Inject]
        private ICateogoryRepoService _repo { get; set; }
        [Inject]
        NotificationService _notice { get; set; }
        protected override void OnInitialized()
        {
            Category = new CategoryDto();
            base.OnInitialized();
        }
        public async Task Submit()
        {
            Loading = true;
            var result = await _repo.Create(Category);
            if (result.Status)
            {
                await _notice.Open(new NotificationConfig()
                {
                    Message = "موفقیت آمیز",
                    Description = result.Message,
                    NotificationType = NotificationType.Success
                });
            }else
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
