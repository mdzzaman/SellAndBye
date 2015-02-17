using SellAndBye.Interface;
using SellAndBye.Models.InputModel;
using SellAndBye.Models.OutputModel;
using SellAndBye.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace SellAndBye.Controllers
{
    [RoutePrefix("api/Password")]
    public class PasswordController : ApiController
    {
        [Authorize]
        public IHttpActionResult Put(PasswordInput password)
        {
            var userInfo = User.Identity;
            var identity = (ClaimsIdentity)User.Identity;
            OutPutModel output = new OutPutModel();
            IPasswordRepository _PasswordRepository = new PasswordRepository();
            if (_PasswordRepository.PassWordCheckByEmail(userInfo.Name, password.OldPassword))
            {
                _PasswordRepository.Update(userInfo.Name, password.NewPassword);
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
