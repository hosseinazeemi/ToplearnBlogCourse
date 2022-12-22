using AntDesign;
using Microsoft.AspNetCore.Components;
using Toplearn_Blog.Dashboard.Repositories.Category;
using Toplearn_Blog.Shared.Dto.Category;
using Toplearn_Blog.Shared.Dto.Global;

namespace Toplearn_Blog.Dashboard.Pages.Category
{
    public partial class CategoryList
    {
        [Inject]
        private ICateogoryRepoService _repo { get; set; }
        [Inject]
        NotificationService _notice { get; set; }
        public List<CategoryDto> Categories { get; set; }
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
                Categories = result.Data;
            }
            else
            {
                Categories = new List<CategoryDto>();
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
        public async Task Remove(CategoryDto category)
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

                Categories.Remove(category);
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
