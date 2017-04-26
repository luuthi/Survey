using System;
using System.Collections.Generic;
using BusinessEntities;

namespace BusinessServices.Interfaces
{
    public interface IRoleServives
    {
        /// <summary>
        /// lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        IList<RolesEntites> GettAllRole();
        /// <summary>
        /// Lấy question theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RolesEntites GetRoleById(string id);
        /// <summary>
        /// thêm mới 1 survey
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool CreateRole(RolesEntites entity);
        /// <summary>
        /// cập nhật 1 survey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateRole(string id, RolesEntites entity);
        /// <summary>
        /// xóa 1 survey
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteRole(string id);
    }
}
