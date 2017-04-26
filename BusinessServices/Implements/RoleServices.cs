using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BusinessEntities;
using BusinessServices.Interfaces;
using BusinessServices.Shareds;
using DataModel;
using DataModel.UnitOfWork;

namespace BusinessServices.Implements
{
    public class RoleServices : IRoleServives
    {
        private readonly UnitOfWork _unit;

        public RoleServices(UnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }

        public bool CreateRole(RolesEntites entity)
        {
            Role newItem = new Role()
            {
                RoleID =  entity.RoleID,
                Status = entity.Status,
                RoleName = entity.RoleName,
                
            };
            _unit.RoleGenericType.Insert(newItem);
            return true;
        }

        public bool DeleteRole(string id)
        {
            bool success = false;
            var deleteItem = _unit.RoleGenericType.GetByID(id);
            if (deleteItem != null)
            {
                _unit.RoleGenericType.Delete(deleteItem);
                _unit.Save();
                success = true;
            }
            return success;
        }

        public RolesEntites GetRoleById(string id)
        {
            var roles = _unit.RoleGenericType.GetByID(id);
            if (roles!=null)
            {
                return Ultis.MapObject<Role,RolesEntites>(roles);
            }
            return null;
        }

        public IList<RolesEntites> GettAllRole()
        {
            var roles = _unit.RoleGenericType.GetAll().ToList();
            if (roles.Any())
            {
                return Ultis.MapList<Role,RolesEntites>(roles);
            }
            return null;
        }

        public bool UpdateRole(string id, RolesEntites entity)
        {
            bool success = false;
            var updateItem = _unit.RoleGenericType.GetByID(id);
            if (updateItem != null)
            {
                updateItem.RoleID = entity.RoleID;
                updateItem.Status = entity.Status;
                updateItem.RoleName = entity.RoleName;

                _unit.RoleGenericType.Update(updateItem);
                _unit.Save();
                success = true;
            }
            return success;
        }
    }
}
