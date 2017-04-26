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
    public class RoleController : ApiController
    {
        private readonly IRoleServives _iRoleServives;

        public RoleController(IRoleServives iRoleServives)
        {
            _iRoleServives = iRoleServives;
        }


        public JsonResult<APIResultEntities<List<RolesEntites>>> Get()
        {
            APIResultEntities<List<RolesEntites>> rs = new APIResultEntities<List<RolesEntites>>();
            try
            {
                var data = _iRoleServives.GettAllRole();
                if (data != null)
                {
                    var lst = data as List<RolesEntites> ?? data.ToList();

                    rs.Data = lst;
                    rs.ErrCode = ErrorCodeEntites.Success;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.Role);
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = ErrorCodeEntites.HaveNoData;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.Role);
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

        public JsonResult<APIResultEntities<RolesEntites>> Get(string id)
        {
            APIResultEntities<RolesEntites> rs = new APIResultEntities<RolesEntites>();
            try
            {
                var data = _iRoleServives.GetRoleById(id);
                if (data != null)
                {
                    rs.Data = data;
                    rs.ErrCode = ErrorCodeEntites.Success;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.Role);

                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = ErrorCodeEntites.HaveNoData;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.Role);
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

        public JsonResult<APIResultEntities<bool>> Post(RolesEntites entity)
        {
            APIResultEntities<bool> rs = new APIResultEntities<bool>();
            try
            {
                _iRoleServives.CreateRole(entity);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_INSERT_SUCCESS, Constants.Role);
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

        public JsonResult<APIResultEntities<bool>> Put(string id, RolesEntites entity)
        {
            APIResultEntities<bool> rs = new APIResultEntities<bool>();
            try
            {
                _iRoleServives.UpdateRole(id, entity);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_UPDATE_SUCCESS, Constants.Role);
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
        public JsonResult<APIResultEntities<bool>> Delete(string id)
        {
            APIResultEntities<bool> rs = new APIResultEntities<bool>();
            try
            {
                _iRoleServives.DeleteRole(id);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_DELETE_SUCCESS, Constants.Role);
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
