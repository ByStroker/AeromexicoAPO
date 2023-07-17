using AeromexicoAPO.Models;
using AeromexicoAPO.Services;
using Microsoft.AspNetCore.Mvc;

namespace AeromexicoAPO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VueloController : Controller
    {
        private readonly IVueloService _VueloService;

        public VueloController(IVueloService vueloService)
        {
            _VueloService = vueloService;
        }

        [HttpGet]
        public IActionResult GetVuelos(string inicio,string fin)
        {
            List<vuelo> vuelos = _VueloService.GetVuelos(inicio, fin); 
           return Ok(vuelos);
        }
    }
}
