using InnoTech.LegosForLife.Security.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InnoTech.LegosForLife.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISecurityService _securityService;

        public AuthController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public ActionResult<TokenDto> Login(LoginDto dto)
        {
            var token = _securityService.GenerateJwtToken(dto.UserName, dto.Password);

            return new TokenDto
            {
                Jwt = token.Jwt,
                Message = token.Message
            };
        }
    }

    public class TokenDto
    {
        public string Jwt { get; set; }
        public string Message { get; set; }
    }

    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
