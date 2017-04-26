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
    public class AccountGroupServices : IAccountGroupServices
    {
        private readonly UnitOfWork _unit;

        public AccountGroupServices(UnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }

        public bool CreateAccountGroup(AccountGroupEntities entity)
        {
            AccountGroup newItem = new AccountGroup()
            {
                GroupID = entity.GroupID,
                GroupName = entity.GroupName,
                Descriptions = entity.Descriptions
            };
            _unit.AccountGroupGenericType.Insert(newItem);
            return true;
        }

        public bool DeleteAccountGroup(string id)
        {
            bool success = false;
            var deleteItem = _unit.AccountGroupGenericType.GetByID(id);
            if (deleteItem != null)
            {
                _unit.AccountGroupGenericType.Delete(deleteItem);
                _unit.Save();
                success = true;
            }
            return success;
        }

        public AccountGroupEntities GetAccountGroupById(string id)
        {
            var accgr = _unit.AccountGroupGenericType.GetByID(id);
            if (accgr != null)
            {
                return Ultis.MapObject<AccountGroup, AccountGroupEntities>(accgr);
            }
            return null;
        }

        public IList<AccountGroupEntities> GetAllAccountGroup()
        {
            var accgr = _unit.AccountGroupGenericType.GetAll().ToList();
            if (accgr.Any())
            {
                return Ultis.MapList<AccountGroup, AccountGroupEntities>(accgr);
            }
            return null;
        }

        public bool UpdateAccountGroup(string id, AccountGroupEntities entity)
        {
            bool success = false;
            var updateItem = _unit.AccountGroupGenericType.GetByID(id);
            if (updateItem != null)
            {
                updateItem.GroupName = entity.GroupName;
                updateItem.Descriptions = entity.Descriptions;

                _unit.AccountGroupGenericType.Update(updateItem);
                _unit.Save();
                success = true;
            }
            return success;
        }
    }
}
