using AntDesign;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text;
using Toplearn_Blog.Dashboard.Repositories.Admin;
using Toplearn_Blog.Dashboard.Services;
using Toplearn_Blog.Shared.Dto.Global;
using Toplearn_Blog.Shared.Dto.User;

namespace Toplearn_Blog.Dashboard.Pages.Admin
{
    public partial class AdminCreate
    {
        [Inject]
        private IAdminRepoService _repo { get; set; }
        [Inject]
        NotificationService _notice { get; set; }

        public UserDto User { get; set; }
        public bool Loading { get; set; } = false;
        protected override Task OnInitializedAsync()
        {
            User = new UserDto();
            return base.OnInitializedAsync();
        }

        public async Task Create()
        {
            Loading = true;
            var result = await _repo.Create(User);

            if (result.Status)
            {
                NoticeWithIcon(NotificationType.Success , "موفقیت آمیز" , result.Message);
            }else
            {
                NoticeWithIcon(NotificationType.Error, "خطا", result.Message);
            }
            await Task.Delay(1500);
            Loading = false;
        }

        private async Task NoticeWithIcon(NotificationType type , string title , string description)
        {
            await _notice.Open(new NotificationConfig()
            {
                Message = title,
                Description = description,
                NotificationType = type
            });
        }
    }
}
