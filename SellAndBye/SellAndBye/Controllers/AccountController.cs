using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Linq;
using SellAndBye.API;
using SellAndBye.Interface;
using SellAndBye.Models;
using SellAndBye.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SellAndBye.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public IHttpActionResult Register(RegisterViewModel model)
        {
            IdentityResult result = new IdentityResult();
            result = null;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IUserRepository _UserRepository = new UserRepository();
            SellAndBye.DataModel.User userInfo = new DataModel.User();
            if (!_UserRepository.UserEmailCheck(model.Email))
            {
                userInfo.Email = model.Email;
                userInfo.Password = model.Password;
                userInfo.Mobile = model.Mobile;
                _UserRepository.Add(userInfo);
                return Ok();
            }
            else
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("This Email already Esist"),
                    ReasonPhrase = "Exception"
                });
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            base.Dispose(disposing);
        }
        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }
            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
                if (ModelState.IsValid)
                {
                    return BadRequest();
                }
                return BadRequest(ModelState);
            }
            return null;
        }
    }
}
