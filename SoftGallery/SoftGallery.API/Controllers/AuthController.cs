using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftGallery.Dominio.DTO;
using SoftGallery.Dominio.Models;
using SoftGallery.Dominio.Services;

namespace SoftGallery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly AuthService service;

        public AuthController(AuthService service)
        {
            this.service = service;
        }

        [HttpGet("me")]
        public ActionResult<Cliente> Me()
        {
            Cliente? cliente = service.Me();
            if (cliente is null)
            {
                return Unauthorized();
            }
            return Ok(cliente);
        }

        [AllowAnonymous]
        [HttpPost("signIn")]
        public ActionResult<string> SignIn([FromBody] SignInDTO parametros)
        {
            string? cliente = service.SignIn(parametros);

            if (cliente is null)
            {
                return Ok("nullo");
            }
            
            return cliente;
        }
    }
}
