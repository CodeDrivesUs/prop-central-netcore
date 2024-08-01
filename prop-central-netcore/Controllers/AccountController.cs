using System;
using Azure.Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;

namespace prop_central_netcore.Controllers
{
    public class AccountController : ControllerBase
    {
        public IActionResult SignIn()
        {
           // var redirectUrl = Url.Action(nameof(HomeController.Secure), "Home");
            return Challenge(new AuthenticationProperties { RedirectUri = "" }, OpenIdConnectDefaults.AuthenticationScheme);
        }

        //public IActionResult SignOut()
        //{
        //   // var callbackUrl = Url.Action(nameof(HomeController.Index), "Home", values: null, protocol: Request.Scheme);
        //    return SignOut(new AuthenticationProperties { RedirectUri = "" },
        //        OpenIdConnectDefaults.AuthenticationScheme, CookieAuthenticationDefaults.AuthenticationScheme);
        //}
    }
}

