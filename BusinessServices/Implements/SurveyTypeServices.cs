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
    public class SurveyTypeServices : ISurveyTypeServices
    {
        private UnitOfWork _unit;

        public SurveyTypeServices(UnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }
        /// <summary>
        /// Them moi 1 surveytype
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool CreateSurveyType(SurveyTypeEntities entity)
        {
            SurveyType newItem = new SurveyType()
            {
                IdSurType = entity.IdSurType,
                TypeName = entity.TypeName,
                Descriptions = entity.Descriptions,
                Status = entity.Status,
                LastEditedAt = entity.LastEditedAt
            };
            _unit.SurveyTypeGenericType.Insert(newItem);
            _unit.Save();
            return true;
        }

        public bool DeleteSurveyType(Guid id)
        {
            bool success = false;
            var deletItem = _unit.SurveyTypeGenericType.GetByID(id);
            if (deletItem!=null)
            {
                _unit.SurveyTypeGenericType.Delete(deletItem);
                _unit.Save();
                success = true;
            }
            return success;

        }

        public IList<SurveyTypeEntities> GetAllSurveyType()
        {
            var data = _unit.SurveyTypeGenericType.GetAll().ToList();
            if (data.Any())
            {
                return Ultis.MapList<SurveyType,SurveyTypeEntities>(data);
            }
            return null;
        }

        public SurveyTypeEntities GetSurveyTypeById(Guid id)
        {
            var data = _unit.SurveyTypeGenericType.GetByID(id);
            if (data!=null)
            {
                return Ultis.MapObject<SurveyType,SurveyTypeEntities>(data);
            }
            return null;
        }

        public bool UpdateSurveyType(Guid id, SurveyTypeEntities entity)
        {
            bool success = false;
            var updateItem = _unit.SurveyTypeGenericType.GetByID(id);
            if (updateItem!=null)
            {
                updateItem.TypeName = entity.TypeName;
                updateItem.Descriptions = entity.Descriptions;
                updateItem.Status = entity.Status;
                updateItem.LastEditedAt = entity.LastEditedAt;
                _unit.SurveyTypeGenericType.Update(updateItem);
                _unit.Save();
                success = true;
            }
            return success;
        }
    }
}
