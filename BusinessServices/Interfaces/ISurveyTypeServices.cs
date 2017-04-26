using BusinessEntities;
using System;
using System.Collections.Generic;

namespace BusinessServices.Interfaces
{

    public interface ISurveyTypeServices
    {
        /// <summary>
        /// lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        IList<SurveyTypeEntities> GetAllSurveyType();
        /// <summary>
        /// Lấy survey theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SurveyTypeEntities GetSurveyTypeById(Guid id);
        /// <summary>
        /// thêm mới 1 survey
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool CreateSurveyType(SurveyTypeEntities entity);
        /// <summary>
        /// cập nhật 1 survey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateSurveyType(Guid id, SurveyTypeEntities entity);
        /// <summary>
        /// xóa 1 survey
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteSurveyType(Guid id);
    }
}
