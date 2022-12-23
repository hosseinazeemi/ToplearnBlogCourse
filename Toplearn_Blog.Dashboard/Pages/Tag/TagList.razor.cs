using AntDesign;
using Microsoft.AspNetCore.Components;
using Toplearn_Blog.Dashboard.Repositories.Tag;
using Toplearn_Blog.Shared.Dto.Global;
using Toplearn_Blog.Shared.Dto.Tag;

namespace Toplearn_Blog.Dashboard.Pages.Tag
{
    public partial class TagList
    {
        [Inject]
        private ITagRepoService _repo { get; set; }
        [Inject]
        NotificationService _notice { get; set; }
        public List<TagDto> Tags { get; set; }
        public bool Loading { get; set; } = false;
        public Paginate PageInfo { get; set; }
        protected override async Task OnInitializedAsync()
        {
            PageInfo = new Paginate();
            await GetList(PageInfo);
        }
        public async Task GetList(Paginate paginate)
        {
            Loading = true;
            var result = await _repo.GetAll(paginate);
            if (result.Status)
            {
                PageInfo = result.Paginate;
                Tags = result.Data;
            }
            else
            {
                Tags = new List<TagDto>();
            }
            await Task.Delay(1000);
            Loading = false;
        }
        public async Task ChangePage(PaginationEventArgs args)
        {
            PageInfo.CurrentPage = args.Page;
            PageInfo.Take = args.PageSize;
            await GetList(PageInfo);
        }
        public async Task Remove(TagDto category)
        {
            Loading = true;
            var result = await _repo.Remove(category.Id);

            if (result.Status)
            {
                await _notice.Open(new NotificationConfig()
                {
                    Message = "پیام تایید",
                    Description = result.Message,
                    NotificationType = NotificationType.Success
                });

                Tags.Remove(category);
            }
            else
            {
                await _notice.Open(new NotificationConfig()
                {
                    Message = "پیام خطا",
                    Description = result.Message,
                    NotificationType = NotificationType.Error
                });
            }
            Loading = false;
            StateHasChanged();
        }
    }
}
