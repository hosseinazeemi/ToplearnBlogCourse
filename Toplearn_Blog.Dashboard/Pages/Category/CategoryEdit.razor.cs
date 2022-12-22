using AntDesign;
using Microsoft.AspNetCore.Components;
using Toplearn_Blog.Dashboard.Repositories.Category;
using Toplearn_Blog.Shared.Dto.Category;

namespace Toplearn_Blog.Dashboard.Pages.Category
{
    public partial class CategoryEdit
    {
        public bool Loading { get; set; }
        public CategoryDto Category { get; set; }
        [Inject]
        private ICateogoryRepoService _repo { get; set; }
        [Inject]
        NotificationService _notice { get; set; }
        [Parameter]
        public int Id { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Loading = true;
            var result = await _repo.GetCategoryById(Id);
            if (result.Status)
            {
                Category = result.Data;
                await _notice.Open(new NotificationConfig()
                {
                    Message = "اطلاعات دریافت شد",
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
        public async Task Submit()
        {
            Loading = true;
            var result = await _repo.Update(Category);
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
