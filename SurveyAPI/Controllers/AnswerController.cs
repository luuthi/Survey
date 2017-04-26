using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using BusinessEntities;
using BusinessServices.Interfaces;
using SurveyAPI.ActionFilters;
using SurveyAPI.Shared;

namespace SurveyAPI.Controllers
{
    [AuthorizationRequired]
    public class AnswerController : ApiController
    {
        private readonly IAnswerServices _iAnswerServices;

        public AnswerController(IAnswerServices iAnswerServices)
        {
            _iAnswerServices = iAnswerServices;
        }

        //Get all
        public JsonResult<APIResultEntities<List<AnswerEntities>>> Get()
        {
            APIResultEntities<List<AnswerEntities>> rs = new APIResultEntities<List<AnswerEntities>>();
            try
            {
                var data = _iAnswerServices.GetAllAnswer();
                if (data!=null)
                {
                    var lst = data as List<AnswerEntities> ?? data.ToList();

                    rs.Data = lst;
                    rs.ErrCode = ErrorCodeEntites.Success;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.Answer);
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = ErrorCodeEntites.HaveNoData;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.Answer);
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

        //get by id
        public JsonResult<APIResultEntities<AnswerEntities>> Get(Guid id)
        {
            APIResultEntities<AnswerEntities> rs = new APIResultEntities<AnswerEntities>();
            try
            {
                var data = _iAnswerServices.GetAnswerById(id);
                if (data!=null)
                {
                    rs.Data = data;
                    rs.ErrCode = ErrorCodeEntites.Success;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.Answer);
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = ErrorCodeEntites.HaveNoData;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.Answer);
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

        // insert

        public JsonResult<APIResultEntities<bool>> Post(AnswerEntities entity)
        {
            APIResultEntities<bool> rs = new APIResultEntities<bool>();
            try
            {
                _iAnswerServices.CreateAnswer(entity);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_INSERT_SUCCESS, Constants.Answer);
            }
            catch (Exception ex)
            {

                rs.Data = false;
                rs.ErrCode = ErrorCodeEntites.Fail;
                rs.ErrDescription = ex.ToString();
                throw new Exception(ex.ToString());
            }
            return Json(rs);
        }

        public JsonResult<APIResultEntities<bool>> Put(Guid id, AnswerEntities entity)
        {
            APIResultEntities<bool> rs = new APIResultEntities<bool>();
            try
            {
                _iAnswerServices.UpdateAnswer(id, entity);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_UPDATE_SUCCESS, Constants.Answer);
            }
            catch (Exception ex)
            {
                rs.Data = false;
                rs.ErrCode = ErrorCodeEntites.Fail;
                rs.ErrDescription = ex.ToString();
                throw new Exception(ex.ToString());
            }
            return Json(rs);
        }
        public JsonResult<APIResultEntities<bool>> Delete(Guid id)
        {
            APIResultEntities<bool> rs = new APIResultEntities<bool>();
            try
            {
                _iAnswerServices.DeleteAnswer(id);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_DELETE_SUCCESS, Constants.Answer);
            }
            catch (Exception ex)
            {
                rs.Data = false;
                rs.ErrCode = ErrorCodeEntites.Fail;
                rs.ErrDescription = ex.ToString();
                throw new Exception(ex.ToString());
            }
            return Json(rs);
        }
    }
}
