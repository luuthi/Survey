using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using BusinessEntities;
using BusinessServices.Interfaces;
using DataModel;
using AutoMapper;
using BusinessServices.Shareds;
using DataModel.UnitOfWork;

namespace BusinessServices.Implements
{
    public class SurveyServices : ISurveyServices
    {
        private readonly UnitOfWork _unit;

        public SurveyServices(UnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }
        /// <summary>
        /// Thêm mới 1 survey
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool CreateSurveyInfo(SurveyInfoEntities entity)
        {
            SurveyInfo newitem = new SurveyInfo()
            {
                IdSurType = entity.IdSurType,
                IdSurvey = entity.IdSurvey,
                SurveyName = entity.SurveyName,
                Descriptions = entity.Descriptions,
                Images = entity.Images,
                CreatedDate = entity.CreatedDate,
                LastEditedAt = entity.LastEditedAt,
                LastEditedBy = entity.LastEditedBy,
                Status = entity.Status,
                OwnedUserID = entity.OwnedUserID
            };
            _unit.SurveyinfoGenericType.Insert(newitem);
            _unit.Save();
            return true;
        }
        /// <summary>
        /// Xóa 1 survey
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteSurveyInfo(Guid id)
        {
            bool success = false;
            var deleteItem = _unit.SurveyinfoGenericType.GetByID(id);
            if (deleteItem != null)
            {
                _unit.SurveyinfoGenericType.Delete(deleteItem);
                _unit.Save();
                success = true;
            }
            return success;
        }
        /// <summary>
        /// Lấy tất cả dữ liệu
        /// </summary>
        /// <returns></returns>
        public IList<SurveyInfoEntities> GetAllSurveyInfo()
        {
            //throw new NotImplementedException();
            var data = _unit.SurveyinfoGenericType.GetAll().ToList();
            if (data.Any())
            {
                return Ultis.MapList<SurveyInfo,SurveyInfoEntities>(data);
            }
            return null;
        }
        /// <summary>
        /// lấy survey theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SurveyInfoEntities GetSurveyInfoById(Guid id)
        {
            var data = _unit.SurveyinfoGenericType.GetByID(id);
            if (data != null)
            {
                return Ultis.MapObject<SurveyInfo,SurveyInfoEntities>(data);
            }
            return null;
        }
        /// <summary>
        /// sửa 1 survey
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateSurveyInfo(Guid id, SurveyInfoEntities entity)
        {
            bool success = false;
            var updateItem = _unit.SurveyinfoGenericType.GetByID(id);
            if (updateItem!=null)
            {
                updateItem.IdSurType = entity.IdSurType;
                updateItem.SurveyName = entity.SurveyName;
                updateItem.Descriptions = entity.Descriptions;
                updateItem.Images = entity.Images;
                updateItem.CreatedDate = entity.CreatedDate;
                updateItem.LastEditedAt = entity.LastEditedAt;
                updateItem.LastEditedBy = entity.LastEditedBy;
                updateItem.Status = entity.Status;
                updateItem.OwnedUserID = entity.OwnedUserID;
                
                _unit.SurveyinfoGenericType.Update(updateItem);
                _unit.Save();
                success = true;

            }
            return success;
        }
    }
}
