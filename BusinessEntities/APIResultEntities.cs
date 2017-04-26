using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class APIResultEntities<T>
    {
        public ErrorCodeEntites ErrCode { get; set; }
        public string ErrDescription { get; set; }
        public T Data { get; set; }

        public APIResultEntities()
        {
            ErrCode = ErrorCodeEntites.NullVal;
        }

        public APIResultEntities(ErrorCodeEntites errcode, T data, string errdesc)
        {
            ErrCode = errcode;
            ErrDescription = errdesc;
            Data = data;
        }
    }
}
