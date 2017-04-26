using BusinessEntities;
using BusinessServices.Interfaces;
using SurveyAPI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using AttributeRouting.Web.Http;
using BusinessServices.Implements;
using SurveyAPI.ActionFilters;

namespace SurveyAPI.Controllers
{
    [AuthorizationRequired]
    public class SurveyTypeController : ApiController
    {
        private readonly ISurveyTypeServices _surveyTypeServices;

        public SurveyTypeController(ISurveyTypeServices iSurveyTypeServices)
        {
            _surveyTypeServices = iSurveyTypeServices;
        }
        public JsonResult<APIResultEntities<List<SurveyTypeEntities>>> Get()
        {
            APIResultEntities<List<SurveyTypeEntities>> rs = new APIResultEntities<List<SurveyTypeEntities>>();
            try
            {
                var surveytypes = _surveyTypeServices.GetAllSurveyType();
                if (surveytypes != null)
                {
                    var lst = surveytypes as List<SurveyTypeEntities> ?? surveytypes.ToList();
                    rs.Data = lst;
                    rs.ErrCode = ErrorCodeEntites.Success;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.SurveyType);
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = ErrorCodeEntites.HaveNoData;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.SurveyType);
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
        public JsonResult<APIResultEntities<SurveyTypeEntities>> Get(Guid id)
        {
            APIResultEntities<SurveyTypeEntities> rs = new APIResultEntities<SurveyTypeEntities>();
            try
            {
                var surtype = _surveyTypeServices.GetSurveyTypeById(id);
                if (surtype != null)
                {
                    rs.Data = surtype;
                    rs.ErrCode = ErrorCodeEntites.Success;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.SurveyType);
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = ErrorCodeEntites.HaveNoData;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.SurveyType);
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
        public JsonResult<APIResultEntities<bool>> Post(SurveyTypeEntities surveyTypeEntities)
        {
            APIResultEntities<bool> rs = new APIResultEntities<bool>();
            try
            {
                _surveyTypeServices.CreateSurveyType(surveyTypeEntities);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_INSERT_SUCCESS, Constants.SurveyType);

            }
            catch (Exception ex)
            {
                rs.Data = false;
                rs.ErrCode = ErrorCodeEntites.Fail;
                rs.ErrDescription = ex.ToString();
            }
            return Json(rs);
        }
        public JsonResult<APIResultEntities<bool>> Put(Guid id,SurveyTypeEntities surveyTypeEntities)
        {
            APIResultEntities<bool> rs = new APIResultEntities<bool>();
            try
            {
                _surveyTypeServices.UpdateSurveyType(id,surveyTypeEntities);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_UPDATE_SUCCESS, Constants.SurveyType);

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
                _surveyTypeServices.DeleteSurveyType(id);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_DELETE_SUCCESS, Constants.SurveyType);

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
