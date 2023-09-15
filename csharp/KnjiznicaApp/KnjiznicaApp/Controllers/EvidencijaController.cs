using KnjiznicaApp.Data;
using KnjiznicaApp.Models;
using KnjiznicaApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace KnjiznicaApp.Controllers
{

    /// <summary>
    /// Namijenjeno za CRUD operacije na entitetu evidencija_posudbe u bazi
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EvidencijaController:ControllerBase
    {

        private readonly KnjiznicaContext _context;
        private readonly ILogger<EvidencijaController> _logger;
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="context"></param>
        public EvidencijaController(KnjiznicaContext context,
            ILogger<EvidencijaController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Dohvacam evidenciju posudbe");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var posudbe = _context.Evidencija
                    .Include(p => p.Clan)
                    .Include(p => p.Knjige)
                    .ToList();
                if (posudbe==null || posudbe.Count== 0)
                {
                    return  new EmptyResult();
                }
                List<EvidencijaDTO> vrati = new();
                posudbe.ForEach(p =>
                {
                    vrati.Add(new EvidencijaDTO()
                    {
                        Id_posudbe = p.Id_posudbe,
                        Datum_posudbe = p.Datum_posudbe,
                        Datum_vracanja = p.Datum_vracanja,
                        Clan = p.Clan.Ime,
                       
                        BrojKnjiga = p.Knjige.Count

                    });
                });
                return Ok(vrati);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.
                    Status503ServiceUnavailable, ex);
            }
        }
    }
}
