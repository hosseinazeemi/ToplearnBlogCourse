using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toplearn_Blog.Shared.Dto.User
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "وارد نام الزامی است")]
        public string Name { get; set; }
        [Required(ErrorMessage = "وارد کردن نام خانوادگی الزامی است")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage ="وارد کردن کلمه عبور الزامی است")]
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
    }
}
