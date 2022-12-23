using Microsoft.AspNetCore.Components;
using Toplearn_Blog.Shared.Dto.Tag;

namespace Toplearn_Blog.Dashboard.Pages.Tag
{
    public partial class TagForm
    {
        [Parameter]
        public TagDto Tag { get; set; }
        [Parameter]
        public EventCallback SubmitCallback { get; set; }
    }
}
