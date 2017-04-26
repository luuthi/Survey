using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using BusinessServices.Interfaces;
using BusinessServices.Shareds;
using DataModel;
using DataModel.UnitOfWork;

namespace BusinessServices.Implements
{
    public class AnswerPaperServices : IAnswerPaperServices
    {
        private readonly UnitOfWork _unit;

        public AnswerPaperServices(UnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }
        public bool CreateAnswerPaper(AnswerPaperEntities entity)
        {
            AnswerPaper newItem = new AnswerPaper()
            {
                IdSurvey = entity.IdSurvey,
                IdAnsPaper = entity.IdAnsPaper,
                CreatedDate = entity.CreatedDate,
                Descriptions = entity.Descriptions,
                Status = entity.Status
            };
            _unit.AnswerPaperGenericType.Insert(newItem);
            return true;
        }

        public bool DeleteAnswerPaper(Guid id)
        {
            bool success = false;
            var deleteItem = _unit.AnswerPaperGenericType.GetByID(id);
            if (deleteItem != null)
            {
                _unit.AnswerPaperGenericType.Delete(deleteItem);
                _unit.Save();
                success = true;
            }
            return success;
        }

        public IList<AnswerPaperEntities> GetAllAnswerPaper()
        {
            var anspaper = _unit.AnswerPaperGenericType.GetAll().ToList();
            if (anspaper.Any())
            {
                return Ultis.MapList<AnswerPaper,AnswerPaperEntities>(anspaper);
            }
            return null;
        }

        public AnswerPaperEntities GetAnswerPaperById(Guid id)
        {
            var anspaper = _unit.AnswerPaperGenericType.GetByID(id);
            if (anspaper!=null)
            {
                return Ultis.MapObject<AnswerPaper,AnswerPaperEntities>(anspaper);
            }
            return null;
        }

        public bool UpdateAnswerPaper(Guid id, AnswerPaperEntities entity)
        {
            bool success = false;
            var updateItem = _unit.AnswerPaperGenericType.GetByID(id);
            if (updateItem != null)
            {
                updateItem.IdSurvey = entity.IdSurvey;
                updateItem.CreatedDate = entity.CreatedDate;
                updateItem.Descriptions = entity.Descriptions;
                updateItem.Status = entity.Status;

                _unit.AnswerPaperGenericType.Update(updateItem);
                _unit.Save();
                success = true;
            }
            return success;
        }
    }
}
