using AeromexicoAPO.Models;

namespace AeromexicoAPO.Services
{
    public interface ILoginService
    {
        string GenerarToken(Usuario usuario);
        bool ValidarCredenciales(string nombreUsuario, string contraseña);
    }

}
