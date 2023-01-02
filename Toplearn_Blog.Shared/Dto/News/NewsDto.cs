using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toplearn_Blog.Shared.Dto.Category;
using Toplearn_Blog.Shared.Dto.Media;
using Toplearn_Blog.Shared.Dto.Tag;
using Toplearn_Blog.Shared.Dto.User;

namespace Toplearn_Blog.Shared.Dto.News
{
    public class NewsDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "وارد کردن عنوان الزامی است")]
        public string Title { get; set; }
        [Required(ErrorMessage = "وارد کردن توضیحات الزامی است")]
        public string Description { get; set; }
        public int Likes { get; set; }
        public int DisLikes { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public bool Selected { get; set; }
        public bool IsPopular { get; set; }
        public bool IsSuggest { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public List<MediaDto> Files { get; set; }
        public List<TagDto> Tags { get; set; }
        public UserDto User { get; set; }
        public CategoryDto Category { get; set; }
    }
}
