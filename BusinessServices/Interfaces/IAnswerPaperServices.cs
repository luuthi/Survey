using System;
using System.Collections.Generic;
using BusinessEntities;

namespace BusinessServices.Interfaces
{
    public interface IAnswerPaperServices
    {
        /// <summary>
        /// lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        IList<AnswerPaperEntities> GetAllAnswerPaper();
        /// <summary>
        /// Lấy question theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AnswerPaperEntities GetAnswerPaperById(Guid id);
        /// <summary>
        /// thêm mới 1 survey
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool CreateAnswerPaper(AnswerPaperEntities entity);
        /// <summary>
        /// cập nhật 1 survey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool UpdateAnswerPaper(Guid id, AnswerPaperEntities entity);
        /// <summary>
        /// xóa 1 survey
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool DeleteAnswerPaper(Guid id);
    }
}
