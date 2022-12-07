using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toplearn_Blog.Domain.Entities
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Likes { get; set; }
        public int DisLikes { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public bool Selected { get; set; }
        public bool IsPopular { get; set; }
        public bool IsSuggest { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Instagram { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }
        public virtual List<Tag> Tags { get; set; }
    }
}
