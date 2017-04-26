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
    public class AnswerServices : IAnswerServices
    {

        private readonly UnitOfWork _unit;

        public AnswerServices(UnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }


        public bool CreateAnswer(AnswerEntities entity)
        {
            Answer newItem = new Answer()
            {
                IdAnswer = entity.IdAnswer,
                IdQuestion = entity.IdQuestion,
                IdChoices = entity.IdChoices,
                IdAnsPaper = entity.IdAnsPaper
            };
            _unit.AnswerGenericType.Insert(newItem);
            return true;
        }

        public bool DeleteAnswer(Guid id)
        {
            bool success = false;
            var deleteItem = _unit.AnswerGenericType.GetByID(id);
            if (deleteItem != null)
            {
                _unit.AnswerGenericType.Delete(deleteItem);
                _unit.Save();
                success = true;
            }
            return success;
        }

        public IList<AnswerEntities> GetAllAnswer()
        {
            var answers = _unit.AnswerGenericType.GetAll().ToList();
            if (answers.Any())
            {
                return Ultis.MapList<Answer,AnswerEntities>(answers);
            }
            return null;
        }

        public AnswerEntities GetAnswerById(Guid id)
        {
            var answers = _unit.AnswerGenericType.GetByID(id);
            if (answers!=null)
            {
                return Ultis.MapObject<Answer,AnswerEntities>(answers);
            }
            return null;
        }

        public bool UpdateAnswer(Guid id, AnswerEntities entity)
        {
            bool success = false;
            var updateItem = _unit.AnswerGenericType.GetByID(id);
            if (updateItem != null)
            {
                updateItem.IdQuestion = entity.IdQuestion;
                updateItem.IdAnsPaper = entity.IdAnsPaper;
                updateItem.IdChoices = entity.IdChoices;

                _unit.AnswerGenericType.Update(updateItem);
                _unit.Save();
                success = true;
            }
            return success;
        }
    }
}
