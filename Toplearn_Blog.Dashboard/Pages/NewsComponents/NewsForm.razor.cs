using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Toplearn_Blog.Dashboard.Repositories.Category;
using Toplearn_Blog.Shared.Dto.Category;
using Toplearn_Blog.Shared.Dto.Global;
using Toplearn_Blog.Shared.Dto.Media;
using Toplearn_Blog.Shared.Dto.News;
using Toplearn_Blog.Shared.Dto.Tag;
using Toplearn_Blog.Shared.Dto.User;

namespace Toplearn_Blog.Dashboard.Pages.NewsComponents
{
    public partial class NewsForm
    {
        [Parameter]
        public NewsDto News { get; set; }
        [Parameter]
        public EventCallback SubmitCallback { get; set; }
        [Parameter]
        public List<CategoryDto> Categories { get; set; }
        [Parameter]
        public List<UserDto> Users { get; set; }
        [Parameter]
        public List<TagDto> Tags { get; set; }
        public IEnumerable<TagDto> selectedTags { get; set; }
        [Inject]
        NotificationService _notice { get; set; }
        public Paginate PageInfo { get; set; }
        protected override async Task OnInitializedAsync()
        {
            News.Files = new List<MediaDto>();
            News.Tags = new List<TagDto>();
            PageInfo = new Paginate();
        }
        public async Task OnSelectFile(List<MediaDto> files)
        {
            News.Files.AddRange(files);
            await _notice.Open(new NotificationConfig()
            {
                Message = "موفقیت آمیز",
                Description = "فایل ها با موفقیت انتخاب شدند",
                NotificationType = NotificationType.Success
            });
        }
        private void OnSelectedCategoryChangedHandler(CategoryDto value)
        {
            News.Category = value;
        }
        private void OnSelectedUserChangedHandler(UserDto value)
        {
            News.User = value;
        }
        private void OnTagsSelected(IEnumerable<TagDto> tags)
        {
            News.Tags.Clear();
            News.Tags.AddRange(tags);
        }
        public async Task Submit()
        {
            await SubmitCallback.InvokeAsync();
        }
    }
}
