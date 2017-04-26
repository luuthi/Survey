using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices.Interfaces
{
    public interface IRoleDetailServices
    {
        /// <summary>
        /// lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        IList<RolesDetailEntites> GettAllRoleDetail();
        /// <summary>
        /// Lấy question theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RolesDetailEntites GetRoleDetailById(string id);
        /// <summary>
        /// thêm mới 1 survey
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool CreateRoleDetail(RolesDetailEntites entity);
        /// <summary>
        /// cập nhật 1 survey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateRoleDetail(string id, RolesDetailEntites entity);
        /// <summary>
        /// xóa 1 survey
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteRoleDetail(string id);
    }
}
