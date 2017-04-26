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
    public class ChoicesServices : IChoicesServices
    {
        private readonly UnitOfWork _unit;

        public ChoicesServices(UnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
        }


        public bool CreateChoices(ChoicesEntites entity)
        {
            Choice newItem = new Choice()
            {
                IdQuestion = entity.IdQuestion,
                IdChoices = entity.IdChoices,
                Content = entity.Content,
                NumericalOrder = entity.NumericalOrder,
                LastEditedAt =  entity.LastEditedAt,
                LastEditedBy = entity.LastEditedBy
            };
            _unit.ChoiceGenericType.Insert(newItem);
            _unit.Save();
            return true;
        }

        public bool DeleteChoices(Guid id)
        {
            bool success = false;
            var deleteItem = _unit.ChoiceGenericType.GetByID(id);
            if (deleteItem != null)
            {
                _unit.ChoiceGenericType.Delete(deleteItem);
                _unit.Save();
                success = true;
            }
            return success;
        }

        public IList<ChoicesEntites> GetAllChoices()
        {
            var choices = _unit.ChoiceGenericType.GetAll().ToList();
            if (choices.Any())
            {
                return Ultis.MapList<Choice,ChoicesEntites>(choices);
            }
            return null;
        }

        public ChoicesEntites GetChoicesById(Guid id)
        {
            var choices = _unit.ChoiceGenericType.GetByID(id);
            if (choices != null)
            {
                return Ultis.MapObject<Choice,ChoicesEntites>(choices); ;
            }
            return null;
        }

        public bool UpdateChoices(Guid id, ChoicesEntites entity)
        {
            bool success = false;
            var updateItem = _unit.ChoiceGenericType.GetByID(id);
            if (updateItem != null)
            {
                updateItem.IdQuestion = entity.IdQuestion;
                updateItem.Content = entity.Content;
                updateItem.NumericalOrder = entity.NumericalOrder;
                updateItem.LastEditedAt = entity.LastEditedAt;
                updateItem.LastEditedBy = entity.LastEditedBy;

                _unit.ChoiceGenericType.Update(updateItem);
                _unit.Save();
                success = true;
            }
            return success;
        }
    }
}
