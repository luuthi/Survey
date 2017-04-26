using System;
using System.Collections.Generic;
using BusinessEntities;

namespace BusinessServices.Interfaces
{
    public interface IQuestionGroupServices
    {
        /// <summary>
        /// lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        IList<QuestionGroupEntities> GettAllQuestionGroup();
        /// <summary>
        /// Lấy question theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        QuestionGroupEntities GetQuestionGroupById(Guid id);
        /// <summary>
        /// thêm mới 1 survey
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool CreateQuestionGroup(QuestionGroupEntities entity);
        /// <summary>
        /// cập nhật 1 survey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateQuestionGroup(Guid id, QuestionGroupEntities entity);
        /// <summary>
        /// xóa 1 survey
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteQuestionGroup(Guid id);
    }
}
