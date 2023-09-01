using KnjiznicaWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KnjiznicaWebApp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class KnjigaController:ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var lista= new List<Knjiga>();
            {
                

            };
            return new JsonResult(lista);
        }
        [HttpPost]
        public IActionResult Post(Knjiga knjiga)
        {
            return Created("/api/v1/Knjiga", knjiga);
        }
        [HttpPut]
        [Route("{ID:int}")]
        public IActionResult Put(int ID,Knjiga knjiga)
        {
            return StatusCode(StatusCodes.Status200OK, knjiga);
        }
        [HttpDelete]
        [Route("{ID:int}")]
        public IActionResult Delete(int ID) 
        {
            return StatusCode(StatusCodes.Status200OK, "{\"obrisano\":true}");
        }
    }
}
