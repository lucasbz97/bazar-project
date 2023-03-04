using ApiMyTask.Controllers;
using Barca.Business.Interfaces.IService;
using Barca.Business.Models;
using Barca.Business.Services;
using Barca.Extensions;
using Barca.ViewModels;
using Dev.Business.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Barca.Controllers
{
    [Route("api")]
    [ApiController]
    //[Authorize]
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IClientService _clientService;
        private readonly IConfiguration _configuration;

        public AuthController(INotificador notificador,
                         SignInManager<IdentityUser> signInManager,
                         UserManager<IdentityUser> userManager,
                         IClientService clientService,
                         IConfiguration configuration) : base(notificador)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _clientService = clientService;
            _configuration = configuration;
        }

        [HttpPost("NewAccount")]
        public async Task<ActionResult> Registrar(RegisterClientViewModel registerUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                EmailConfirmed = true
            };

            var client = new Client
            {
                Name = registerUser.Email,
                Email = registerUser.Email,
                CreateDate = DateTime.Now,
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);
            await _clientService.Adicionar(client);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, true);

                return CustomResponse(registerUser);
            }
            foreach (var error in result.Errors)
            {
                NotificarError(error.Description);
            }

            return CustomResponse(registerUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginClientViewModel loginUser)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var user = new IdentityUser
            {
                UserName = loginUser.Email,
                Email = loginUser.Email,
                EmailConfirmed = true
            };


            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                    _configuration.GetSection("AppSettings:Secret").Value));

                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred);

                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                loginUser.ClientToken = jwt;
                return CustomResponse(loginUser);
            }

            NotificarError("Usuário ou senha incorretos");
            return CustomResponse(loginUser);
        }
    }
}
