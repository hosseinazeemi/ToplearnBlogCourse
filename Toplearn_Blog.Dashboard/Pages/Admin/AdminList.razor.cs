using AntDesign;
using Microsoft.AspNetCore.Components;
using Toplearn_Blog.Dashboard.Repositories.Admin;
using Toplearn_Blog.Shared.Dto.Global;
using Toplearn_Blog.Shared.Dto.User;

namespace Toplearn_Blog.Dashboard.Pages.Admin
{
    public partial class AdminList
    {
        [Inject]
        private IAdminRepoService _repo { get; set; }
        [Inject]
        NotificationService _notice { get; set; }
        public List<UserDto> Users { get; set; }
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
                Users = result.Data;
            }
            else
            {
                Users = new List<UserDto>();
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
        public async Task Remove(UserDto user)
        {
            Loading = true;
            var result = await _repo.Remove(user.Id);

            if (result.Status)
            {
                await _notice.Open(new NotificationConfig()
                {
                    Message = "پیام تایید",
                    Description = result.Message,
                    NotificationType = NotificationType.Success
                });

                Users.Remove(user);
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
        public void Cancel()
        {
            // --
        }
        public async Task ChangeState(int id)
        {
            Loading = true;
            var result = await _repo.ChangeState(id);

            if (result.Status)
            {
                Users.Where(p => p.Id == id).ForEach(p => p.IsActive = !p.IsActive);
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
            Loading = false;
        }
    }
}
