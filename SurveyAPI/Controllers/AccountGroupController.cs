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
    public class AccountGroupController : ApiController
    {
        private readonly IAccountGroupServices _iAccountGroupServices;

        public AccountGroupController(IAccountGroupServices iAccountGroupServices)
        {
            _iAccountGroupServices = iAccountGroupServices;
        }


        public JsonResult<APIResultEntities<List<AccountGroupEntities>>> Get()
        {
            APIResultEntities<List<AccountGroupEntities>> rs = new APIResultEntities<List<AccountGroupEntities>>();
            try
            {
                var data = _iAccountGroupServices.GetAllAccountGroup();
                if (data != null)
                {
                    var lst = data as List<AccountGroupEntities> ?? data.ToList();

                    rs.Data = lst;
                    rs.ErrCode = ErrorCodeEntites.Success;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.AccountnGroup);
                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = ErrorCodeEntites.HaveNoData;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.AccountnGroup);
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

        public JsonResult<APIResultEntities<AccountGroupEntities>> Get(string id)
        {
            APIResultEntities<AccountGroupEntities> rs = new APIResultEntities<AccountGroupEntities>();
            try
            {
                var data = _iAccountGroupServices.GetAccountGroupById(id);
                if (data != null)
                {
                    rs.Data = data;
                    rs.ErrCode = ErrorCodeEntites.Success;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.AccountnGroup);

                }
                else
                {
                    rs.Data = null;
                    rs.ErrCode = ErrorCodeEntites.HaveNoData;
                    rs.ErrDescription = string.Format(Constants.MSG_SELECT_SUCCESS, Constants.AccountnGroup);
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

        public JsonResult<APIResultEntities<bool>> Post(AccountGroupEntities entity)
        {
            APIResultEntities<bool> rs = new APIResultEntities<bool>();
            try
            {
                _iAccountGroupServices.CreateAccountGroup(entity);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_INSERT_SUCCESS, Constants.AccountnGroup);
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

        public JsonResult<APIResultEntities<bool>> Put(string id, AccountGroupEntities entity)
        {
            APIResultEntities<bool> rs = new APIResultEntities<bool>();
            try
            {
                _iAccountGroupServices.UpdateAccountGroup(id, entity);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_UPDATE_SUCCESS, Constants.AccountnGroup);
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
                _iAccountGroupServices.DeleteAccountGroup(id);
                rs.Data = true;
                rs.ErrCode = ErrorCodeEntites.Success;
                rs.ErrDescription = string.Format(Constants.MSG_DELETE_SUCCESS, Constants.AccountnGroup);
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
