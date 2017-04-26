using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public enum ErrorCodeEntites
    {
        //Null Value
        NullVal = -1000,

        //Msg
        Success = 0,
        Fail,
        HaveNoData,
        ExistentData,

        //Connect DB
        Connect = 100,
        Disconnect,
    }
}
