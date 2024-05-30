using API92.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API92.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;
        public UsuariosController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var response = await _usuarioServices.GetUsuarios();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody]UsuariosResponse request)
        {
            var response = await _usuarioServices.CrearUsuario(request);
            return Ok(response);
        }
    }
}
