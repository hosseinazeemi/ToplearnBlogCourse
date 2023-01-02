using AntDesign;
using Microsoft.AspNetCore.Components;
using Toplearn_Blog.Dashboard.Repositories.News;
using Toplearn_Blog.Shared.Dto.Global;
using Toplearn_Blog.Shared.Dto.News;

namespace Toplearn_Blog.Dashboard.Pages.NewsComponents
{
    public partial class NewsList
    {
        [Inject]
        private INewsRepoService _repo { get; set; }
        [Inject]
        NotificationService _notice { get; set; }
        public List<NewsDto> News { get; set; }
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
                News = result.Data;
            }
            else
            {
                News = new List<NewsDto>();
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
        public async Task Remove(NewsDto news)
        {
            Loading = true;
            var result = await _repo.Remove(news.Id);

            if (result.Status)
            {
                await _notice.Open(new NotificationConfig()
                {
                    Message = "پیام تایید",
                    Description = result.Message,
                    NotificationType = NotificationType.Success
                });

                News.Remove(news);
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

        public async Task ChangeState(bool state, NewsDto news)
        {
            var result = await _repo.ChangeState(news.Id);
            if (result.Status)
            {
                await _notice.Open(new NotificationConfig()
                {
                    Message = "پیام تایید",
                    Description = result.Message,
                    NotificationType = NotificationType.Success
                });
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
        }
    }
}
