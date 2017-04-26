using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using BusinessEntities;
using BusinessServices.Implements;
using BusinessServices.Interfaces;
using SurveyAPI.ActionFilters;
using SurveyAPI.Shared;

namespace SurveyAPI.Controllers
{
    [AuthorizationRequired]
    public class QuestionTypeController : ApiController
    {
        private readonly IQuestionTypeService _iQuestionTypeService;

        public QuestionTypeController(IQuestionTypeService iQuestionTypeService)
        {
            _iQuestionTypeService = iQuestionTypeService;
        }

        public JsonResult<APIResultEntities<List<QuestionTypeEntities>>> Get()
        {
            APIResultEntities<List<QuestionTypeEntities>> rs= new APIResultEntities<List<QuestionTypeEntities>>();
            try
            {
                var data = _iQuestionTypeService.GettAllQuestionType();
                if (data!=null)
                {
                    var lst = data as List<QuestionTypeEntities> ?? data.ToList();
                    rs.Data = lst;
                    rs.ErrCode = ErrorCodeEntites.Success;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.QuestionType);
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = ErrorCodeEntites.HaveNoData;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.QuestionType);
                }
            }
            catch (Exception ex)
            {
                rs.Data = null;
                rs.ErrCode = ErrorCodeEntites.Fail;
                rs.ErrDescription = ex.ToString();
            }
            return Json(rs);
        }

        public JsonResult<APIResultEntities<QuestionTypeEntities>> Get(Guid id)
        {
            APIResultEntities<QuestionTypeEntities> rs= new APIResultEntities<QuestionTypeEntities>();
            try
            {
                var data = _iQuestionTypeService.GetQuestionTypeById(id);
                if (data!=null)
                {
                    rs.Data = data;
                    rs.ErrCode = ErrorCodeEntites.Success;
                    rs.ErrDescription= string.Format(Constants.MSG_SELECT_SUCCESS, Constants.QuestionType);
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = ErrorCodeEntites.HaveNoData;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.QuestionType);
                }
            }
            catch (Exception ex)
            {

                rs.Data = null;
                rs.ErrCode = ErrorCodeEntites.Fail;
                rs.ErrDescription = ex.ToString();
            }
            return Json(rs);

        }

        public JsonResult<APIResultEntities<bool>> Post(QuestionTypeEntities entity)
        {
            APIResultEntities<bool> rs= new APIResultEntities<bool>();
            try
            {
                _iQuestionTypeService.CreateQuestionType(entity);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_INSERT_SUCCESS, Constants.QuestionType);
            }
            catch (Exception ex)
            {

                rs.Data = false;
                rs.ErrCode = ErrorCodeEntites.Fail;
                rs.ErrDescription = ex.ToString();
            }
            return Json(rs);
        }

        public JsonResult<APIResultEntities<bool>> Put(Guid id, QuestionTypeEntities entity)
        {
            APIResultEntities<bool> rs = new APIResultEntities<bool>();
            try
            {
                _iQuestionTypeService.UpdateQuestionType(id,entity);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_UPDATE_SUCCESS, Constants.QuestionType);
            }
            catch (Exception ex)
            {
                rs.Data = false;
                rs.ErrCode = ErrorCodeEntites.Fail;
                rs.ErrDescription = ex.ToString();
            }
            return Json(rs);
        }
        public JsonResult<APIResultEntities<bool>> Delete(Guid id)
        {
            APIResultEntities<bool> rs = new APIResultEntities<bool>();
            try
            {
                _iQuestionTypeService.DeleteQuestionType(id);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_DELETE_SUCCESS, Constants.QuestionType);
            }
            catch (Exception ex)
            {
                rs.Data = false;
                rs.ErrCode = ErrorCodeEntites.Fail;
                rs.ErrDescription = ex.ToString();
            }
            return Json(rs);
        }
    }
}
