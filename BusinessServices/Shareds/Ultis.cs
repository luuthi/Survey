using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataModel.GenericType;

namespace BusinessServices.Shareds
{
    public static class Ultis
    {
        public static List<R> MapList<T,R>(List<T> data )
        {
            Mapper.CreateMap<T, R>();
            var rs = Mapper.Map<List<T>, List<R>>(data);
            return rs;
        }

        public static R MapObject<T, R>(T data)
        {
            Mapper.CreateMap<T, R>();
            var rs = Mapper.Map<T, R>(data);
            return rs;
        }
    }
}
