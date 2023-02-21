using ApiMyTask.Controllers;
using Barca.ViewModels;
using Dev.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Barca.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(INotificador notificador,
                         SignInManager<IdentityUser> signInManager,
                         UserManager<IdentityUser> userManager) : base(notificador)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("NewAccount")]
        public async Task<ActionResult> Registrar(RegisterUserViewModel registerUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);//segundo param, quardar infor para facilitar o login 
                return CustomResponse(registerUser);
            }
            foreach (var error in result.Errors)
            {
                NotificarError(error.Description);
            }

            return CustomResponse(registerUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUser.Email, loginUser.Password, false, true);
            //4 ° para lockar o user caso tenha muita tentativa de acesso, por default acho que é 5min de lock

            if (result.Succeeded)
            {
                return CustomResponse(loginUser);
            }
            if (result.IsLockedOut)
            {
                NotificarError("Usuário temporariamente bloqueado, tente novamente mais tarde");
                return CustomResponse(loginUser);
            }

            NotificarError("Usuário ou senha incorretos");
            return CustomResponse(loginUser);
        }
    }
}
