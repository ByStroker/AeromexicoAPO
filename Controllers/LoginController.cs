using AeromexicoAPO.Models;
using AeromexicoAPO.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AeromexicoAPO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public IActionResult Login(Usuario request)
        {
            bool credencialesValidas = _loginService.ValidarCredenciales(request.NombreUsuario, request.Contraseña);

            if (!credencialesValidas)
            {
                return Unauthorized();
            }

            //Usuario usuario = ObtenerUsuarioDesdeBaseDeDatos(request.NombreUsuario);
            Usuario usuario = new Usuario();
            usuario.NombreUsuario =request.NombreUsuario;

            string token = _loginService.GenerarToken(usuario);

            return Ok(new { Token = token });
        }

        
    }

}
