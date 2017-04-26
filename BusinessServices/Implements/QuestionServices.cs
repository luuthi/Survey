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
    public class QuestionServices : IQuestionServices
    {
        private readonly UnitOfWork _unit;

        public QuestionServices(UnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }

        public bool CreateQuestion(QuestionEntities entity)
        {
            Question newItem = new Question()
            {
                IdSurvey = entity.IdSurvey,
                IdQuesType = entity.IdQuesType,
                IdQuestion = entity.IdQuestion,
                IdQuestionGroup = entity.IdQuestionGroup,
                Content = entity.Content,
                Images = entity.Images,
                NumericalOrder = entity.NumericalOrder,
                Status = entity.Status,
                IsRequired = entity.IsRequired,
                LastEditedAt = entity.LastEditedAt,
                LastEditedBy = entity.LastEditedBy,
            };
            _unit.QuestionGenericType.Insert(newItem);
            _unit.Save();
            return true;
        }

        public bool DeleteQuestion(Guid id)
        {
            bool success = false;
            var deleteItem = _unit.QuestionGenericType.GetByID(id);
            if (deleteItem!=null)
            {
                _unit.QuestionGenericType.Delete(deleteItem);
                _unit.Save();
                success = true;
            }
            return success;
        }

        public QuestionEntities GetQuestionById(Guid id)
        {
            var data = _unit.QuestionGenericType.GetByID(id);
            if (data!=null)
            {
                return Ultis.MapObject<Question,QuestionEntities>(data);
            }
            return null;
        }

        public IList<QuestionEntities> GettAllQuestion()
        {
            var data = _unit.QuestionGenericType.GetAll().ToList();
            if (data.Any())
            {
                return Ultis.MapList<Question,QuestionEntities>(data);
            }
            return null;
        }

        public bool UpdateQuestion(Guid id, QuestionEntities entity)
        {
            bool success = false;
            var updateItem = _unit.QuestionGenericType.GetByID(id);
            if (updateItem!=null)
            {
                entity.IdSurvey = entity.IdSurvey;
                entity.IdQuesType = entity.IdQuesType;
                entity.IdQuestionGroup = entity.IdQuestionGroup;
                entity.Content = entity.Content;
                entity.Images = entity.Images;
                entity.NumericalOrder = entity.NumericalOrder;
                entity.Status = entity.Status;
                entity.IsRequired = entity.IsRequired;
                entity.LastEditedAt = entity.LastEditedAt;
                entity.LastEditedBy = entity.LastEditedBy;
                _unit.QuestionGenericType.Update(updateItem);
                _unit.Save();
                success = true;
            }
            return success;
        }
    }
}
