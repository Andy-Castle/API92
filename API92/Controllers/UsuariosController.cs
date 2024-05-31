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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _usuarioServices.GetById(id);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody]UsuariosResponse request)
        {
            var response = await _usuarioServices.CrearUsuario(request);
            return Ok(response);
        }

        //Hay que el Actualizar me pida este asi [HttpDelete("{id}")]
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody]UsuariosResponse request)
        {
            var response = await _usuarioServices.ActualizarUsuario(request);
            return Ok(response);
        }

        //Hay que el Eliminar me pida este asi [HttpDelete("{id}")]
        [HttpDelete]
        public async Task<IActionResult> Eliminar([FromBody]UsuariosResponse request)
        {
            var response = await _usuarioServices.EliminarUsuario(request);
            return Ok(response);
        }
    }
}
