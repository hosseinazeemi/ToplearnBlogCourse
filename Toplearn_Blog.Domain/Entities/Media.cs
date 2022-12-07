using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toplearn_Blog.Domain.Entities
{
    public class Media
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public string TableName { get; set; }
        public int TableRowId { get; set; }
        public string TableField { get; set; }
    }
}
