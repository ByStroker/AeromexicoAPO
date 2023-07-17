using AeromexicoAPO.Models;

namespace AeromexicoAPO.Services
{
    public interface IVueloService
    {
        List<vuelo> GetVuelos(string inicio,string fin);
        List<vuelo> PostVuelo();
    }
}
