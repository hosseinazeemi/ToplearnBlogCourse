using Toplearn_Blog.Shared.Dto.User;

namespace Toplearn_Blog.Dashboard.Pages.Admin
{
    public partial class AdminCreate
    {
        public UserDto User { get; set; }
        protected override Task OnInitializedAsync()
        {
            User = new UserDto();
            return base.OnInitializedAsync();
        }

        public async Task Create()
        {

        }
    }
}
