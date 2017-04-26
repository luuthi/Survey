using System;
using System.Collections.Generic;
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
    public class AnswerPaperController : ApiController
    {
        private readonly IAnswerPaperServices _iAnswerPaperServices;

        public AnswerPaperController(IAnswerPaperServices iAnswerPaperServices)
        {
            _iAnswerPaperServices = iAnswerPaperServices;
        }

        //Get all
        public JsonResult<APIResultEntities<List<AnswerPaperEntities>>> Get()
        {
            APIResultEntities<List<AnswerPaperEntities>> rs = new APIResultEntities<List<AnswerPaperEntities>>();
            try
            {
                var data = _iAnswerPaperServices.GetAllAnswerPaper();
                if (data != null)
                {
                    var lst = data as List<AnswerPaperEntities> ?? data.ToList();

                    rs.Data = lst;
                    rs.ErrCode = ErrorCodeEntites.Success;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.AnswerPaper);
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = ErrorCodeEntites.HaveNoData;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.AnswerPaper);
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
        public JsonResult<APIResultEntities<AnswerPaperEntities>> Get(Guid id)
        {
            APIResultEntities<AnswerPaperEntities> rs = new APIResultEntities<AnswerPaperEntities>();
            try
            {
                var data = _iAnswerPaperServices.GetAnswerPaperById(id);
                if (data != null)
                {
                    rs.Data = data;
                    rs.ErrCode = ErrorCodeEntites.Success;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.AnswerPaper);
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = ErrorCodeEntites.HaveNoData;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.AnswerPaper);
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

        public JsonResult<APIResultEntities<bool>> Post(AnswerPaperEntities entity)
        {
            APIResultEntities<bool> rs = new APIResultEntities<bool>();
            try
            {
                _iAnswerPaperServices.CreateAnswerPaper(entity);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_INSERT_SUCCESS, Constants.AnswerPaper);
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

        public JsonResult<APIResultEntities<bool>> Put(Guid id, AnswerPaperEntities entity)
        {
            APIResultEntities<bool> rs = new APIResultEntities<bool>();
            try
            {
                _iAnswerPaperServices.UpdateAnswerPaper(id, entity);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_UPDATE_SUCCESS, Constants.AnswerPaper);
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
                _iAnswerPaperServices.DeleteAnswerPaper(id);
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
