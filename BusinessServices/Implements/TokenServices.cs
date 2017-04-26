using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using BusinessEntities;
using BusinessServices.Interfaces;
using DataModel.UnitOfWork;
using System.Configuration;
using DataModel;

namespace BusinessServices.Implements
{
    public class TokenServices : ITokenServices
    {
        private readonly UnitOfWork _unit;

        public TokenServices(UnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }
        public bool DeleteByUserId(Guid UserId)
        {
            _unit.TokenGenericType.Delete(x => x.UserId == UserId);
            _unit.Save();
            var isDeleted = _unit.TokenGenericType.GetMany(x => x.UserId == UserId).Any();
            return !isDeleted;
        }

        public TokenEntities GenerateToken(Guid UserId)
        {
            Guid token = Guid.NewGuid();
            DateTime issuedOn = DateTime.Now;
            DateTime expireOn = DateTime.Now.AddSeconds(Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
            var tokenModel = new Token()
            {
                TokenId = token,
                UserId = UserId,
                AuthToken = token.ToString(),
                ExpireOn = expireOn,
                IssuedOn = issuedOn
            };
            _unit.TokenGenericType.Insert(tokenModel);
            _unit.Save();
            var tokenEnities = new TokenEntities()
            {
                TokenId = token,
                UserId = UserId,
                AuthToken = token.ToString(),
                ExpireOn = expireOn,
                IssuedOn = issuedOn
            };
            return tokenEnities;
        }

        public bool Kill(string tokenid)
        {
            Guid g;
            if (Guid.TryParse(tokenid, out g))
            {
                _unit.TokenGenericType.Delete(x => x.TokenId == g);
                _unit.Save();
                var isDeleted = _unit.TokenGenericType.GetMany(x => x.UserId == g).Any();
                if (isDeleted)
                {
                    return false;
                }
                return true;
            }
            return true;
        }

        public bool ValidateToken(string tokenid)
        {

            var token = _unit.TokenGenericType.Get(o => o.AuthToken == tokenid && o.ExpireOn > DateTime.Now);
            if (token!=null && !(DateTime.Now > token.ExpireOn))
            {
                token.ExpireOn = token.ExpireOn.AddSeconds(
                                            Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]));
                _unit.TokenGenericType.Update(token);
                _unit.Save();
                return true;
            }
            return false;

        }
    }
}
