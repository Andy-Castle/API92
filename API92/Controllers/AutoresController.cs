using API92.Services;
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

        
    }
}
