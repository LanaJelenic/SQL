using KnjiznicaApp.Data;
using KnjiznicaApp.Models;
using KnjiznicaApp.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;


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
        /// <summary>
        /// Dohvaća sve evidencije posudbe koje su pohranjene u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    GET api/v1/Evidencija
        ///
        /// </remarks>
        /// <returns>Evidencije u bazi</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="400">Zahtjev ne valja (BadRequest)</response> 
        /// <response code="503">Error na serveru</response> 

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
                var posudbe = _context.Evidencija_posudbe
                     .Include(p => p.Clan)
                      .Include(p => p.Knjige)
                     .ToList();
                 if (posudbe==null || posudbe.Count== 0)
                 {
                     return  new EmptyResult();
                 }
                 List<Evidencija_posudbeDTO> posudba = new();
                 posudbe.ForEach(p =>
                 {
                     posudba.Add(new Evidencija_posudbeDTO()
                     {
                         Id_posudbe = p.Id_posudbe,
                         Datum_posudbe = p.Datum_posudbe,
                         Datum_vracanja = p.Datum_vracanja,
                         Clan = p.Clan.Ime,
                         IdClana = (int)p.Clan.Id_clana,
                         

                     });
                 });
                 return Ok(posudba);
              
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.
                    Status503ServiceUnavailable, ex);
            }
        }
        /// <summary>
        /// Unosi novu evidenciju posudbe u bazu podataka
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    POST api/v1/Evidencija
        ///    {Id_clana:,Datum_posudbe:YY-MM-DD}
        ///
        /// </remarks>
        /// <returns>Evidencija je uspjesno kreirana</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="400">Zahtjev nije valjan (BadRequest)</response> 
        /// <response code="503">Error na serveru</response> 
        [HttpPost]
        public IActionResult Post(Evidencija_posudbeDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (dto.IdClana<=0)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var clan = _context.Clan.Find(dto.IdClana);
                if (clan==null)
                {
                    return BadRequest(ModelState);
                }
                Evidencija_posudbe e = new()
                {
                    Clan = clan,
                    Datum_posudbe = dto.Datum_posudbe,
                    Datum_vracanja = dto.Datum_vracanja
                };
                _context.Evidencija_posudbe.Add(e);
                _context.SaveChanges();

                dto.Id_posudbe = e.Id_posudbe;
                dto.Clan = clan.Ime;
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(
                                   StatusCodes.Status503ServiceUnavailable,
                                   ex);
            }
        }
        /// <summary>
        /// Mijenja podatke postojeće evidencije u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    PUT api/v1/Evidencija/1
        ///
        /// {
        ///  "Id": 0,
        ///  "Id_clana": ,
        ///  "Datum_posudbe": ,
        ///  "Datum_vracanja": "Novi datum",
        ///  
        ///  
        /// }
        ///
        /// </remarks>
        /// <param name="Id">Id posudbe koja se mijenja</param>  
        /// <returns>Svi poslani podaci knjige</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">U bazi ne postoji knjiga koju zelimo promijeniti</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Error u serveru</response> 
        [HttpPut]
        public IActionResult Put(int Id_posudbe, Evidencija_posudbeDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (Id_posudbe<=0 || dto==null)
            {
                return BadRequest();
            }
            try
            {
                var clan = _context.Clan.Find(dto.IdClana);
                if (clan==null)
                {
                    return BadRequest();
                }
                var evidencija = _context.Evidencija_posudbe.Find(Id_posudbe);
                if (evidencija==null)
                {
                    return BadRequest();
                }
                evidencija.Clan = clan;
                evidencija.Datum_posudbe=dto.Datum_posudbe;
                evidencija.Datum_vracanja = dto.Datum_vracanja;
                _context.Evidencija_posudbe.Update(evidencija);
                _context.SaveChanges();

                dto.Id_posudbe = Id_posudbe;
                dto.Clan = clan.Ime;

                return Ok(dto);

            }
            catch (Exception ex)
            {
                return StatusCode(
                                    StatusCodes.Status503ServiceUnavailable,
                                    ex.Message);
            }
        }

        /// <summary>
        /// Briše evidenciju iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    DELETE api/v1/evidencija posudbe/1
        ///    
        /// </remarks>
        /// <param name="Id">Id posudbe koju zelimo obrisati</param>  
        /// <returns>Odgovor da li je obrisano ili ne</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">U bazi ne postoji knjiga koju zelimo obrisati</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Error na serveru</response>
        [HttpDelete]
        public IActionResult Delete(int Id_posudbe)
        {
            if (Id_posudbe<=0)
            {
                return BadRequest();
            }
            var evidencijaBaza = _context.Evidencija_posudbe.Find(Id_posudbe);
            if (evidencijaBaza==null)
            {
                return BadRequest();
            }
            try
            {
                _context.Evidencija_posudbe.Remove(evidencijaBaza);
                _context.SaveChanges();
                return new JsonResult("{\"poruka\":\"Obrisano\"}");


            }
            catch (Exception ex)
            {

                return new JsonResult("{\"poruka\":\"Ne može se obrisati\"}");
            }
        }

        


    }
}


