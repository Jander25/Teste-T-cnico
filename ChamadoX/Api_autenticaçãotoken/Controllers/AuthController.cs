using Api_autenticaçãotoken.Dtos;
using Api_autenticaçãotoken.Services.AuthServices;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Api_autenticaçãotoken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthInterface _authInterface;
        public AuthController(IAuthInterface authInterface)
        {
            _authInterface = authInterface;
            
        }


        [HttpPost("login")]
        public async Task<ActionResult> Register(UsuarioCriacaoDto usuarioRegister)
        {
           
            return Ok();
        }


        [HttpPost]
        public async Task<ActionResult> Register(UsuarioCriacaoDto usuarioRegister)
        {
            var respsta =await _authInterface.Registrar(usuarioRegister);
            return Ok(respsta);
        }

    }
}
