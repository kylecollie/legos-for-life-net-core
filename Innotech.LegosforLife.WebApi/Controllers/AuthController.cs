using InnoTech.LegosForLife.Security.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Authentication;

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
            try
            {
                var token = _securityService.GenerateJwtToken(dto.Username, dto.Password);

                return Ok(
                    new TokenDto
                    {
                        Jwt = token.Jwt,
                        Message = token.Message
                    });
            }
            catch (AuthenticationException ae)
            {
                return Unauthorized(ae.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Please contact admin");
            }

        }

        [Authorize]
        [HttpPost(nameof(Create))]
        public ActionResult<AuthUserDto> Create([FromBody] CreateUserAuthDto dto)
        {
            try
            {
                var authUser = _securityService.GenerateNewAuthuser(dto.Username);
                return Ok(new AuthUserDto
                {
                    Id = authUser.Id,
                    Username = authUser.UserName
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(500, "Contact admin");
            }

        }
    }

    public class CreateUserAuthDto
    {
        public string Username { get; set; }
    }

    public class AuthUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }

    public class TokenDto
    {
        public string Jwt { get; set; }
        public string Message { get; set; }
    }

    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
