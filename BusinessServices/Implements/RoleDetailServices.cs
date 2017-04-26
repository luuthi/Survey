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
    public class RoleDetailServices : IRoleDetailServices
    {
        private readonly UnitOfWork _unit;

        public RoleDetailServices(UnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }

        public bool CreateRoleDetail(RolesDetailEntites entity)
        {
            RolesDetail newItem = new RolesDetail()
            {
                RoleDetailID = entity.RoleDetailID,
                RoleID = entity.RolesID,
                GroupID = entity.GroupID,
                Add_ = entity.Add_,
                Update_ = entity.Update_,
                Delete_ = entity.Delete_,
                View_ = entity.View_

            };
            _unit.RoleDetailGenericType.Insert(newItem);
            return true;
        }

        public bool DeleteRoleDetail(string id)
        {
            bool success = false;
            var deleteItem = _unit.RoleDetailGenericType.GetByID(id);
            if (deleteItem != null)
            {
                _unit.RoleDetailGenericType.Delete(deleteItem);
                _unit.Save();
                success = true;
            }
            return success;
        }

        public RolesDetailEntites GetRoleDetailById(string id)
        {
            var roles = _unit.RoleDetailGenericType.GetByID(id);
            if (roles != null)
            {
                return Ultis.MapObject<RolesDetail,RolesDetailEntites>(roles);
            }
            return null;
        }

        public IList<RolesDetailEntites> GettAllRoleDetail()
        {
            var roles = _unit.RoleDetailGenericType.GetAll().ToList();
            if (roles.Any())
            {
                return Ultis.MapList<RolesDetail, RolesDetailEntites>(roles);
            }
            return null;
        }

        public bool UpdateRoleDetail(string id, RolesDetailEntites entity)
        {
            bool success = false;
            var updateItem = _unit.RoleDetailGenericType.GetByID(id);
            if (updateItem != null)
            {
                updateItem.RoleID = entity.RolesID;
                updateItem.GroupID = entity.GroupID;
                updateItem.Add_ = entity.Add_;
                updateItem.Update_ = entity.Update_;
                updateItem.Delete_ = entity.Delete_;
                updateItem.View_ = entity.View_;

                _unit.RoleDetailGenericType.Update(updateItem);
                _unit.Save();
                success = true;
            }
            return success;
        }
    }
}
