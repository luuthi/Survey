using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Interfaces
{
    public interface ISurveyServices
    {
        /// <summary>
        /// lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        IList<SurveyInfoEntities> GetAllSurveyInfo();
        /// <summary>
        /// Lấy survey theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SurveyInfoEntities GetSurveyInfoById(Guid id);
        /// <summary>
        /// thêm mới 1 survey
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool CreateSurveyInfo(SurveyInfoEntities entity);
        /// <summary>
        /// cập nhật 1 survey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateSurveyInfo(Guid id, SurveyInfoEntities entity);
        /// <summary>
        /// xóa 1 survey
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteSurveyInfo(Guid id);
    }
}
