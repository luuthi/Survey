using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    public class QuestionGroupController : ApiController
    {
        private readonly IQuestionGroupServices _iQuestionGroupServices;

        public QuestionGroupController(IQuestionGroupServices iQuestionGroupServices)
        {
            _iQuestionGroupServices = iQuestionGroupServices;
        }


        public JsonResult<APIResultEntities<List<QuestionGroupEntities>>> Get()
        {
            APIResultEntities<List<QuestionGroupEntities>> rs = new APIResultEntities<List<QuestionGroupEntities>>();
            try
            {
                var data = _iQuestionGroupServices.GettAllQuestionGroup();
                if (data!=null)
                {
                    var lst = data as List<QuestionGroupEntities> ?? data.ToList();

                    rs.Data = lst;
                    rs.ErrCode = ErrorCodeEntites.Success;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.QuestionGroup);
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = ErrorCodeEntites.HaveNoData;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.QuestionGroup);
                }
            }
            catch (Exception ex)
            {
                rs.Data = null;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = ex.ToString();
            }
            return Json(rs);
        }

        public JsonResult<APIResultEntities<QuestionGroupEntities>> Get(Guid id)
        {
            APIResultEntities<QuestionGroupEntities> rs = new APIResultEntities<QuestionGroupEntities>();
            try
            {
                var data = _iQuestionGroupServices.GetQuestionGroupById(id);
                if (data!=null)
                {
                    rs.Data = data;
                    rs.ErrCode = ErrorCodeEntites.Success;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.QuestionGroup);

                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = ErrorCodeEntites.HaveNoData;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.QuestionGroup);
                }
            }
            catch (Exception)
            {
                rs.Data = null;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.QuestionGroup);
            }
            return Json(rs);
        }

        public JsonResult<APIResultEntities<bool>> Post(QuestionGroupEntities entity)
        {
            APIResultEntities<bool> rs = new APIResultEntities<bool>();
            try
            {
                _iQuestionGroupServices.CreateQuestionGroup(entity);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_INSERT_SUCCESS, Constants.QuestionGroup);
            }
            catch (Exception ex)
            {

                rs.Data = false;
                rs.ErrCode = ErrorCodeEntites.Fail;
                rs.ErrDescription = ex.ToString();
            }
            return Json(rs);
        }
        public JsonResult<APIResultEntities<bool>> Put(Guid id, QuestionGroupEntities entity)
        {
            APIResultEntities<bool> rs = new APIResultEntities<bool>();
            try
            {
                _iQuestionGroupServices.UpdateQuestionGroup(id, entity);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_UPDATE_SUCCESS, Constants.QuestionGroup);
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
                _iQuestionGroupServices.DeleteQuestionGroup(id);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_DELETE_SUCCESS, Constants.QuestionGroup);
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
