using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using BusinessServices.Interfaces;
using BusinessServices.Shareds;
using DataModel;
using DataModel.UnitOfWork;

namespace BusinessServices.Implements
{
    public class AccountServices : IAccountServices
    {
        private readonly UnitOfWork _unit;

        public AccountServices(UnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }

        public AcountsEntities Authenticate(string userName, string password)
        {
            var user = _unit.AccontGenericType.Get(u => u.Username == userName && u.Passwords == password);
            if (user!=null && user.UserId != Guid.Empty)
            {
                return Ultis.MapObject<Account, AcountsEntities>(user); ;
            }
            return null;
        }

        public bool CreateAccount(AcountsEntities entity)
        {
            Account newItem = new Account()
            {
                GroupID =  entity.GroupId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Gender = entity.Gender,
                Status = entity.Status,
                Avatar = entity.Avatar,
                Birthday = entity.Birthday,
                Mail = entity.Mail,
                Passwords = entity.Passwords,
                Username = entity.UserName
            };
            _unit.AccontGenericType.Insert(newItem);
            return true;
        }

        public bool DeleteAccount(Guid id)
        {
            bool success = false;
            var deleteItem = _unit.AccontGenericType.GetByID(id);
            if (deleteItem != null)
            {
                _unit.AccontGenericType.Delete(deleteItem);
                _unit.Save();
                success = true;
            }
            return success;
        }

        public AcountsEntities GetAccountById(Guid id)
        {
            var acc = _unit.AccontGenericType.GetByID(id);
            if (acc != null)
            {
                return Ultis.MapObject<Account, AcountsEntities>(acc);
            }
            return null;
        }
        public IList<AcountsEntities> GetAllAccount()
        {
            var acc = _unit.AccontGenericType.GetAll().ToList();
            if (acc.Any())
            {
                return Ultis.MapList<Account,AcountsEntities>(acc);
            }
            return null;
        }

        public bool UpdateAccount(Guid id, AcountsEntities entity)
        {
            bool success = false;
            var updateItem = _unit.AccontGenericType.GetByID(id);
            if (updateItem != null)
            {
                updateItem.GroupID = entity.GroupId;
                updateItem.FirstName = entity.FirstName;
                updateItem.LastName = entity.LastName;
                updateItem.Gender = entity.Gender;
                updateItem.Status = entity.Status;
                updateItem.Avatar = entity.Avatar;
                updateItem.Birthday = entity.Birthday;
                updateItem.Mail = entity.Mail;
                updateItem.Passwords = entity.Passwords;
                updateItem.Username = entity.UserName;

                _unit.AccontGenericType.Update(updateItem);
                _unit.Save();
                success = true;
            }
            return success;
        }
    }
}
