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
    public class ChoicesController : ApiController
    {
        private readonly IChoicesServices _iChoicesServices;

        public ChoicesController(IChoicesServices iChoicesServices)
        {
            _iChoicesServices = iChoicesServices;
        }


        public JsonResult<APIResultEntities<List<ChoicesEntites>>> Get()
        {
            APIResultEntities<List<ChoicesEntites>> rs = new APIResultEntities<List<ChoicesEntites>>();
            try
            {
                var data = _iChoicesServices.GetAllChoices();
                if (data != null)
                {
                    var lst = data as List<ChoicesEntites> ?? data.ToList();

                    rs.Data = lst;
                    rs.ErrCode = ErrorCodeEntites.Success;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.Choices);
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = ErrorCodeEntites.HaveNoData;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.Choices);
                }
            }
            catch (Exception ex)
            {
                rs.Data = null;
                rs.ErrCode = ErrorCodeEntites.Fail;
                rs.ErrDescription = ex.ToString();
                throw new Exception(ex.ToString());
            }
            return Json(rs);
        }

        public JsonResult<APIResultEntities<ChoicesEntites>> Get(Guid id)
        {
            APIResultEntities<ChoicesEntites> rs = new APIResultEntities<ChoicesEntites>();
            try
            {
                var data = _iChoicesServices.GetChoicesById(id);
                if (data != null)
                {
                    rs.Data = data;
                    rs.ErrCode = ErrorCodeEntites.Success;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.Choices);

                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = ErrorCodeEntites.HaveNoData;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.Choices);
                }
            }
            catch (Exception ex)
            {
                rs.Data = null;
                rs.ErrCode = ErrorCodeEntites.Fail;
                rs.ErrDescription = ex.ToString();
                throw new Exception(ex.ToString());
            }
            return Json(rs);
        }

        public JsonResult<APIResultEntities<bool>> Post(ChoicesEntites entity)
        {
            APIResultEntities<bool> rs = new APIResultEntities<bool>();
            try
            {
                _iChoicesServices.CreateChoices(entity);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_INSERT_SUCCESS, Constants.Choices);
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

        public JsonResult<APIResultEntities<bool>> Put(Guid id, ChoicesEntites entity)
        {
            APIResultEntities<bool> rs = new APIResultEntities<bool>();
            try
            {
                _iChoicesServices.UpdateChoices(id, entity);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_UPDATE_SUCCESS, Constants.Choices);
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
                _iChoicesServices.DeleteChoices(id);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_DELETE_SUCCESS, Constants.Choices);
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
