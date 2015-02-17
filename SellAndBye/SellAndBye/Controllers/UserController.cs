using SellAndBye.DataModel;
using SellAndBye.Interface;
using SellAndBye.Models.OutputModel;
using SellAndBye.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace SellAndBye.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        [Authorize]
        public IHttpActionResult Get()
        {
            var userInfo = User.Identity;
            var identity = (ClaimsIdentity)User.Identity;
            IUserRepository _UserRepository = new UserRepository();
            SellAndBye.DataModel.User userData = new DataModel.User();
            try
            {
                userData = _UserRepository.UserInfoByEmail(identity.Name);
                userData.Password = "";
                return Ok(userData);
            }
            catch (Exception e) {
                userData = null;
                return Ok(userData);
            }
        }

        [Authorize]
        public IHttpActionResult Put(User user)
        {
            var userInfo = User.Identity;
            var identity = (ClaimsIdentity)User.Identity;
            OutPutModel output = new OutPutModel();
            IUserRepository _UserRepository = new UserRepository();

            if (_UserRepository.Update(user.Id, user))
            {
                output.IsError = false;
                return Ok(output);
            }
            else
            {
                output.IsError = true;
                return Ok(output);
            }
        }

        [Authorize]
        public IHttpActionResult Delete(string id)
        {
            var userInfo = User.Identity;
            var identity = (ClaimsIdentity)User.Identity;
            OutPutModel output = new OutPutModel();
            IUserRepository _UserRepository = new UserRepository();
            if (_UserRepository.Delete(id))
            {
                output.IsError = false;
                return Ok(output);
            }
            else
            {
                output.IsError = true;
                return Ok(output);
            }
        }
    }
}
