using AntDesign;
using Microsoft.AspNetCore.Components;
using Toplearn_Blog.Dashboard.Repositories.Tag;
using Toplearn_Blog.Shared.Dto.Tag;

namespace Toplearn_Blog.Dashboard.Pages.TagComponents
{
    public partial class TagEdit
    {
        public bool Loading { get; set; }
        public TagDto Tag { get; set; }
        [Inject]
        private ITagRepoService _repo { get; set; }
        [Inject]
        NotificationService _notice { get; set; }
        [Parameter]
        public int Id { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Loading = true;
            var result = await _repo.GetTagById(Id);
            if (result.Status)
            {
                Tag = result.Data;
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
            var result = await _repo.Update(Tag);
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
