using System;
using System.Collections.Generic;
using BusinessEntities;

namespace BusinessServices.Interfaces
{
    public interface IAccountGroupServices
    {
        /// <summary>
        /// lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        IList<AccountGroupEntities> GetAllAccountGroup();
        /// <summary>
        /// Lấy question theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AccountGroupEntities GetAccountGroupById(string id);
        /// <summary>
        /// thêm mới 1 survey
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool CreateAccountGroup(AccountGroupEntities entity);
        /// <summary>
        /// cập nhật 1 survey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateAccountGroup(string id, AccountGroupEntities entity);
        /// <summary>
        /// xóa 1 survey
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteAccountGroup(string id);
    }
}
