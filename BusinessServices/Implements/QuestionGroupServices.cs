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
    public class QuestionGroupServices : IQuestionGroupServices
    {
        private readonly UnitOfWork _unit;

        public QuestionGroupServices(UnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }

        public bool CreateQuestionGroup(QuestionGroupEntities entity)
        {
            QuestionGroup newItem =new QuestionGroup()
            {
                IdQuestionGroup = entity.IdQuestionGroup,
                Content = entity.Content,
                LastEditedAt =  entity.LastEditedAt,
                LastEditedBy = entity.LastEditedBy,
            };
            _unit.QuestionGroupGenericType.Insert(newItem);
            _unit.Save();
            return true;
        }

        public bool DeleteQuestionGroup(Guid id)
        {
            bool success = false;
            var deleteItem = _unit.QuestionGroupGenericType.GetByID(id);
            if (deleteItem!=null)
            {
                _unit.QuestionGroupGenericType.Delete(deleteItem);
                _unit.Save();
                success = true;
            }
            return success;
        }

        public QuestionGroupEntities GetQuestionGroupById(Guid id)
        {
            var questiongroup = _unit.QuestionGroupGenericType.GetByID(id);
            if (questiongroup!=null)
            {
                return Ultis.MapObject<QuestionGroup,QuestionGroupEntities>(questiongroup);
            }
            return null;
        }

        public IList<QuestionGroupEntities> GettAllQuestionGroup()
        {
            var questiongroup = _unit.QuestionGroupGenericType.GetAll().ToList();
            if (questiongroup.Any())
            {
                return Ultis.MapList<QuestionGroup,QuestionGroupEntities>(questiongroup);
            }
            return null;
        }

        public bool UpdateQuestionGroup(Guid id, QuestionGroupEntities entity)
        {
            bool success = false;
            var updateItem = _unit.QuestionGroupGenericType.GetByID(id);
            if (updateItem!=null)
            {
                updateItem.Content = entity.Content;
                updateItem.LastEditedAt = entity.LastEditedAt;
                updateItem.LastEditedBy = entity.LastEditedBy;

                _unit.QuestionGroupGenericType.Update(updateItem);
                _unit.Save();
                success = true;
            }
            return success;

        }
    }
}
