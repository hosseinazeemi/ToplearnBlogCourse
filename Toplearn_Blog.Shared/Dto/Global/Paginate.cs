using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toplearn_Blog.Shared.Dto.Global
{
    public class Paginate
    {
        public Paginate()
        {

        }
        public Paginate(int currentPage, int take, int allItemsCount)
        {
            CurrentPage = currentPage;
            Take = take; 
            Skip = (currentPage - 1) * take;
            AllItemsCount = allItemsCount;
            double items = allItemsCount / take;
            AllPagesCount = (int)Math.Ceiling(items);
        }

        public int CurrentPage { get; set; } = 1;
        public int Take { get; set; } = 3; // Limit 
        public int Skip { get; set; } // Offset
        public int AllItemsCount { get; set; }
        public int AllPagesCount { get; set; }
    }
}
