using BusinessEntities;
using BusinessServices.Interfaces;
using SurveyAPI.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using BusinessServices.Implements;
using SurveyAPI.ActionFilters;

namespace SurveyAPI.Controllers
{
    [AuthorizationRequired]
    public class SurveyInfoController : ApiController
    {
        //private member
        private readonly ISurveyServices _iSurveyServices;

        public SurveyInfoController(ISurveyServices iSurveyServices)
        {
            _iSurveyServices = iSurveyServices;
        }
        //public member for CRUD
        // api/surveyinfo
        public JsonResult<APIResultEntities<List<SurveyInfoEntities>>> Get()
        {
            APIResultEntities<List<SurveyInfoEntities>> rs= new APIResultEntities<List<SurveyInfoEntities>>();
            try
            {
                var surveys = _iSurveyServices.GetAllSurveyInfo();
                if (surveys != null)
                {
                    var lst = surveys as List<SurveyInfoEntities> ?? surveys.ToList();
                    if (lst.Any())
                    {
                        rs.Data = lst;
                        rs.ErrCode = ErrorCodeEntites.Success;
                        rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.SurveyInfo);
                    }
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = ErrorCodeEntites.HaveNoData;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.SurveyInfo);
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
        // api/SurveyInfo/id
        public JsonResult<APIResultEntities<SurveyInfoEntities>> Get(Guid id)
        {
            APIResultEntities<SurveyInfoEntities> rs =new APIResultEntities<SurveyInfoEntities>();
            try
            {
                var survey = _iSurveyServices.GetSurveyInfoById(id);
                if (survey!=null)
                {
                    rs.Data = survey;
                    rs.ErrCode = ErrorCodeEntites.Success;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.SurveyInfo);
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = ErrorCodeEntites.HaveNoData;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.SurveyInfo);
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

        // api/SurveyInfo
        public JsonResult<APIResultEntities<bool>> Post(SurveyInfoEntities surveyInfoEntities)
        {
            APIResultEntities<bool> rs= new APIResultEntities<bool>();
            try
            {
                _iSurveyServices.CreateSurveyInfo(surveyInfoEntities);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_INSERT_SUCCESS, Constants.SurveyInfo);
            }
            catch (Exception ex)
            {
                rs.Data = false;
                rs.ErrCode = ErrorCodeEntites.Fail;
                rs.ErrDescription = ex.ToString();
            }
            return Json(rs);
        }
        //api/SurveyInfo/id
        public JsonResult<APIResultEntities<bool>> Put(Guid id, SurveyInfoEntities surveyInfoEntities)
        {
            APIResultEntities<bool> rs= new APIResultEntities<bool>();
            try
            {
                _iSurveyServices.UpdateSurveyInfo(id, surveyInfoEntities);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_UPDATE_SUCCESS, Constants.SurveyInfo);
            }
            catch (Exception ex)
            {
                rs.Data = false ;
                rs.ErrCode = ErrorCodeEntites.Fail;
                rs.ErrDescription = ex.ToString();
            }
            return Json(rs);
        }
        // api/Survey/id
        public JsonResult<APIResultEntities<bool>> Delete(Guid id)
        {
            APIResultEntities<bool> rs = new APIResultEntities<bool>();
            try
            {
                _iSurveyServices.DeleteSurveyInfo(id);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_DELETE_SUCCESS, Constants.SurveyInfo);
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
