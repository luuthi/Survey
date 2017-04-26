using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices.Interfaces
{
    public interface ITokenServices
    {
        /// <summary>
        /// Generate token 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        TokenEntities GenerateToken(Guid UserId);
        /// <summary>
        /// validattion 
        /// </summary>
        /// <param name="tokenid"></param>
        /// <returns></returns>
        bool ValidateToken(string tokenid);
        /// <summary>
        /// kill provided token
        /// </summary>
        /// <param name="tokenid"></param>
        /// <returns></returns>
        bool Kill(string tokenid);
        /// <summary>
        /// delete token by userid
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        bool DeleteByUserId(Guid UserId);
    }
}
