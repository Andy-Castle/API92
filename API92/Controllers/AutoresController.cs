using API92.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API92.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {

        private readonly IAutorServices _autorServices;
        public AutoresController(IAutorServices autorServices) { 
        
            _autorServices = autorServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAutores()
        {
            try
            {
                var result = await _autorServices.GetAutores();
                return Ok(result);
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var autor = new Autor { PkAutor = id };
                var result = await _autorServices.GetById(autor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public async Task<IActionResult> CrearAutor([FromBody]Autor autor)
        {
            try
            {
                var result = await _autorServices.Crear(autor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarAutor(int id, [FromBody]Autor autor)
        {
            try
            {
                autor.PkAutor = id;
                var result = await _autorServices.Editar(autor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarAutor(int id)
        {
            try
            {
                var autor = new Autor { PkAutor = id };
                var result = await _autorServices.Eliminar(autor);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
