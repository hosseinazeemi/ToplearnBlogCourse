using Microsoft.AspNetCore.Components;
using Toplearn_Blog.Shared.Dto.Category;

namespace Toplearn_Blog.Dashboard.Pages.CategoryComponents
{
    public partial class CategoryForm
    {
        [Parameter]
        public CategoryDto Category { get; set; }
        [Parameter]
        public EventCallback SubmitCallback { get; set; }
    }
}
