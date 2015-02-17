using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using SellAndBye.DataModel;
using SellAndBye.Interface;
using SellAndBye.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace SellAndBye.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            IUserRepository _UserRepository = new UserRepository();
            var user = _UserRepository.UserCheckByEmailAndPassword(context.UserName, context.Password);
            User userData = _UserRepository.UserInfoByEmail(context.UserName);
            if (!user)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Email, userData.Email));
            identity.AddClaim(new Claim(ClaimTypes.Sid, userData.Id));

            context.Validated(identity);

        }

    }
}