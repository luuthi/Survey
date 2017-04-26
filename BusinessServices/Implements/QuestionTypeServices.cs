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
    public class QuestionTypeServices : IQuestionTypeService
    {
        private readonly UnitOfWork _unit;

        public QuestionTypeServices(UnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }
        public bool CreateQuestionType(QuestionTypeEntities entity)
        {
            QuestionType newItem = new QuestionType()
            {
                IdQuesType = entity.IdQuestionType,
                TypeName = entity.TypeName,
                Status = entity.Status,
                LastEditedAt = entity.LastEditedAt,
                LastEditedBy = entity.LastEditedBy
            };
            _unit.QuestionTypeGenericType.Insert(newItem);
            _unit.Save();
            return true;
        }

        public bool DeleteQuestionType(Guid id)
        {
            bool success = false;
            var deleteItem = _unit.QuestionTypeGenericType.GetByID(id);
            if (deleteItem!=null)
            {
                _unit.QuestionTypeGenericType.Delete(deleteItem);
                _unit.Save();
                success = true;
            }
            return success;
        }

        public QuestionTypeEntities GetQuestionTypeById(Guid id)
        {
            var questiontype = _unit.QuestionTypeGenericType.GetByID(id);
            if (questiontype!=null)
            {
                return Ultis.MapObject<QuestionType,QuestionTypeEntities>(questiontype);
            }
            return null;
        }

        public IList<QuestionTypeEntities> GettAllQuestionType()
        {
            var questiontype = _unit.QuestionTypeGenericType.GetAll().ToList();
            if(questiontype.Any())
            {
                return Ultis.MapList<QuestionType, QuestionTypeEntities>(questiontype);
            }
            return null;
        }

        public bool UpdateQuestionType(Guid id, QuestionTypeEntities entity)
        {
            bool success = false;
            var updateItem = _unit.QuestionTypeGenericType.GetByID(id);
            if (updateItem!=null)
            {
                updateItem.TypeName = entity.TypeName;
                updateItem.Status = entity.Status;
                updateItem.LastEditedAt = entity.LastEditedAt;
                updateItem.LastEditedBy = entity.LastEditedBy;

                _unit.QuestionTypeGenericType.Update(updateItem);
                _unit.Save();
                success = true;
            }
            return success;
        }
    }
}
