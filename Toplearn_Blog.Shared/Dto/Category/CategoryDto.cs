using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toplearn_Blog.Shared.Dto.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "وارد کردن نام دسته بندی الزامی است")]
        public string Name { get; set; }
    }
}
