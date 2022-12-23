using AntDesign;
using Microsoft.AspNetCore.Components;
using Toplearn_Blog.Dashboard.Repositories.Tag;
using Toplearn_Blog.Shared.Dto.Tag;

namespace Toplearn_Blog.Dashboard.Pages.Tag
{
    public partial class TagCreate
    {
        public bool Loading { get; set; }
        public TagDto Tag { get; set; }
        [Inject]
        private ITagRepoService _repo { get; set; }
        [Inject]
        NotificationService _notice { get; set; }
        protected override void OnInitialized()
        {
            Tag = new TagDto();
            base.OnInitialized();
        }
        public async Task Submit()
        {
            Loading = true;
            var result = await _repo.Create(Tag);
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
