using ApiMyTask.Controllers;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Dev.Business.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Barca.Controllers
{
    [Route("api/externalSocial")]
    [ApiController]
    [Authorize]
    public class ExternalSocialController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public ExternalSocialController (INotificador notificador,
                         SignInManager<IdentityUser> signInManager,
                         UserManager<IdentityUser> userManager) : base(notificador)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("google/login")]
        public ActionResult Index()
        {
            return new ChallengeResult(
                GoogleDefaults.AuthenticationScheme,
                new AuthenticationProperties
                {
                    RedirectUri = Url.Action("GoogleResponse", "GoogleLogin") // Where google responds back
                });
        }

        private async Task<ActionResult> GoogleResponse()
        {
            var authenticateResult = await HttpContext.AuthenticateAsync("External");
            if (!authenticateResult.Succeeded)
            {
                NotificarError("Erro ao realizar autenticação Google");
                return CustomResponse();
            }

            if (authenticateResult.Principal.Identities.ToList()[0].AuthenticationType.ToLower() == "google")
            {
                //check if principal value exists or not 
                if (authenticateResult.Principal != null)
                {
                    //get google account id for any operation to be carried out on the basis of the id
                    var googleAccountId = authenticateResult.Principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    //claim value initialization as mentioned on the startup file with o.DefaultScheme = "Application"
                    var claimsIdentity = new ClaimsIdentity("Application");
                    if (authenticateResult.Principal != null)
                    {
                        //Now add the values on claim and redirect to the page to be accessed after successful login
                        var details = authenticateResult.Principal.Claims.ToList();
                        claimsIdentity.AddClaim(authenticateResult.Principal.FindFirst(ClaimTypes.NameIdentifier));// Full Name Of The User
                        claimsIdentity.AddClaim(authenticateResult.Principal.FindFirst(ClaimTypes.Email)); // Email Address of The User
                        await HttpContext.SignInAsync("Application", new ClaimsPrincipal(claimsIdentity));
                        return CustomResponse();
                    }
                }
            }
            return CustomResponse();
        }

        [HttpPost("google/signout")]
        public async Task<ActionResult> SignOutFromGoogleLogin()
        {
            //Check if any cookie value is present
            if (HttpContext.Request.Cookies.Count > 0)
            {
                //Check for the cookie value with the name mentioned for authentication and delete each cookie
                var siteCookies = HttpContext.Request.Cookies.Where(c => c.Key.Contains(".AspNetCore.") || c.Key.Contains("Microsoft.Authentication"));
                foreach (var cookie in siteCookies)
                {
                    Response.Cookies.Delete(cookie.Key);
                }
            }
            //signout with any cookie present 
            await HttpContext.SignOutAsync("External");

            return CustomResponse();
        }
    }
}
