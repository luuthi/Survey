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
    public class QuestionController : ApiController
    {
        private readonly IQuestionServices _iQuestionServices;

        public QuestionController(IQuestionServices iQuestionServices)
        {
            _iQuestionServices = iQuestionServices;
        }

        public JsonResult<APIResultEntities<List<QuestionEntities>>> Get()
        {
            APIResultEntities<List<QuestionEntities>> rs = new APIResultEntities<List<QuestionEntities>>();
            try
            {
                var questions = _iQuestionServices.GettAllQuestion();
                if (questions != null)
                {
                    var lst = questions as List<QuestionEntities> ?? questions.ToList();
                    rs.Data = lst;
                    rs.ErrCode = ErrorCodeEntites.Success;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.Question);
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = ErrorCodeEntites.HaveNoData;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.Question);
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

        public JsonResult<APIResultEntities<QuestionEntities>> Get(Guid id)
        {
            APIResultEntities<QuestionEntities> rs = new APIResultEntities<QuestionEntities>();
            try
            {
                var question = _iQuestionServices.GetQuestionById(id);
                if (question != null)
                {
                    rs.Data = question;
                    rs.ErrCode = ErrorCodeEntites.Success;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.Question);
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = ErrorCodeEntites.HaveNoData;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.Question);
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


        public JsonResult<APIResultEntities<bool>> Post(QuestionEntities questionEntities)
        {
            APIResultEntities<bool> rs = new APIResultEntities<bool>();
            try
            {
                _iQuestionServices.CreateQuestion(questionEntities);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_INSERT_SUCCESS, Constants.Question);

            }
            catch (Exception ex)
            {
                rs.Data = false;
                rs.ErrCode = ErrorCodeEntites.Fail;
                rs.ErrDescription = ex.ToString();
            }
            return Json(rs);
        }


        public JsonResult<APIResultEntities<bool>> Put(Guid id,QuestionEntities questionEntities)
        {
            APIResultEntities<bool> rs = new APIResultEntities<bool>();
            try
            {
                _iQuestionServices.UpdateQuestion(id,questionEntities);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_UPDATE_SUCCESS, Constants.Question);

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
                _iQuestionServices.DeleteQuestion(id);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_DELETE_SUCCESS, Constants.Question);

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
