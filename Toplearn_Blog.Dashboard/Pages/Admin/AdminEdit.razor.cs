using AntDesign;
using Microsoft.AspNetCore.Components;
using Toplearn_Blog.Dashboard.Repositories.Admin;
using Toplearn_Blog.Shared.Dto.User;

namespace Toplearn_Blog.Dashboard.Pages.Admin
{
    public partial class AdminEdit
    {
        [Inject]
        private IAdminRepoService _repo { get; set; }
        [Inject]
        NotificationService _notice { get; set; }
        [Inject]
        private NavigationManager _nav { get; set; }

        public UserDto User { get; set; }
        [Parameter]
        public int Id { get; set; }
        public bool Loading { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            Loading = true;
            User = new UserDto();
            var result = await _repo.GetUserById(Id);
            if (result.Status)
            {
                User = result.Data;
                await _notice.Open(new NotificationConfig()
                {
                    Message = "پیام دریافت",
                    Description = result.Message,
                    NotificationType = NotificationType.Info
                });
            }
            else
            {
                await _notice.Open(new NotificationConfig()
                {
                    Message = "پیام خطا",
                    Description = "سیستم با خطا مواجه شد ، لطفا مجددا تلاش نمایید",
                    NotificationType = NotificationType.Error
                });
            }
            Loading = false;
            await base.OnInitializedAsync();
        }

        public async Task Update()
        {
            Loading = true;
            var result = await _repo.Update(User);

            if (result.Status)
            {
                await _notice.Open(new NotificationConfig()
                {
                    Message = "پیام تایید",
                    Description = result.Message,
                    NotificationType = NotificationType.Success
                });

                _nav.NavigateTo("/dashboard/admins/list");
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
