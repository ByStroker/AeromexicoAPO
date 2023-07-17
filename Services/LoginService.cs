using AeromexicoAPO.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AeromexicoAPO.Services
{
    public class LoginService : ILoginService
    {
        // Aquí, tendrías que agregar la lógica para obtener usuarios y validar credenciales desde tu fuente de datos (por ejemplo, una base de datos)

        public string GenerarToken(Usuario usuario)
        {
            // Genera el token JWT utilizando la información del usuario y una clave secreta
            var tokenHandler = new JwtSecurityTokenHandler();
            var claveSecreta = Encoding.ASCII.GetBytes("tu_clave_secreta");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.NombreUsuario)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(claveSecreta), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool ValidarCredenciales(string nombreUsuario, string contraseña)
        {
            if (nombreUsuario == "user" && contraseña == "123")
            {
                return true;
            }
            return false;
            // Aquí, tendrías que implementar la lógica para validar las credenciales del usuario, por ejemplo, consultando una base de datos
            // Devuelve true si las credenciales son válidas, de lo contrario, devuelve false.
        }
    }

}
