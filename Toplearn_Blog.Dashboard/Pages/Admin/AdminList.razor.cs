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
