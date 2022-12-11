using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toplearn_Blog.Shared.Dto.Global
{
    public class RepoResultDto<TData>
    {
        public Paginate Paginate { get; set; }
        public TData Data { get; set; }
    }
}
