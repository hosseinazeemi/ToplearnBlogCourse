using Microsoft.AspNetCore.Components;
using Toplearn_Blog.Dashboard.Repositories.Admin;
using Toplearn_Blog.Shared.Dto.User;

namespace Toplearn_Blog.Dashboard.Pages.Admin
{
    public partial class AdminList
    {
        [Inject]
        private IAdminRepoService _repo { get; set; }
        public List<UserDto> Users { get; set; }
        public bool Loading { get; set; } = false;
        protected override async Task OnInitializedAsync()
        {
            Loading = true;
            var result = await _repo.GetAll();
            if (result.Status)
            {
                Users = result.Data;
            }else
            {
                Users = new List<UserDto>();
            }
            await Task.Delay(1000);
            Loading = false;
        }
        public async Task BeginRemove(int id)
        {

        }
        public async Task ChangeState(int id)
        {

        }
        public async Task Edit(int id)
        {

        }
    }
}
