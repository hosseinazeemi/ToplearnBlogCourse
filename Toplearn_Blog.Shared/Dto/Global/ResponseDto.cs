using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toplearn_Blog.Shared.Dto.Global
{
    public class ResponseDto<TResult>
    {
        public ResponseDto()
        {

        }
        public ResponseDto(bool status, string message, TResult data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
        public ResponseDto(bool status, string message, TResult data , Paginate pageInfo)
        {
            Status = status;
            Message = message;
            Data = data;
            Paginate = pageInfo;
        }

        public bool Status { get; set; }
        public string Message { get; set; }
        public TResult Data { get; set; }
        public Paginate Paginate { get; set; }
    }
}
