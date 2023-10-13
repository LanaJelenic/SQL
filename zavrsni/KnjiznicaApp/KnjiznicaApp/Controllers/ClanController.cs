using KnjiznicaApp.Data;
using KnjiznicaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
namespace KnjiznicaApp.Controllers
{
    /// <summary>
    /// Namijenjeno za CRUD operacije na entitetu clan u bazi
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClanController:ControllerBase
    {
        private readonly KnjiznicaContext _context;
        
        public ClanController(KnjiznicaContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Dohvaća sve clanove koji su pohranjeni u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    GET api/v1/Clan
        ///
        /// </remarks>
        /// <returns>Clanovi u bazi</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="400">Zahtjev ne valja (BadRequest)</response> 
        /// <response code="503">Error na serveru</response> 

        [HttpGet]
        public IActionResult Get() 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var clanovi = _context.Clan.ToList();
                if (clanovi==null || clanovi.Count==0)
                {
                    return new EmptyResult();
                }
                return new JsonResult(_context.Clan.ToList());
            }

            catch (Exception ex)
            {
              return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
              
            }
        }

        [HttpGet]
        [Route("{id_clana:int}")]
        public IActionResult GetByID(int id_clana)
        {
            if (id_clana<=0) {
                return BadRequest(ModelState);
            }
            try
            {
                var i = _context.Clan.Find(id_clana);
                if (i==null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, i);
                }
                return new JsonResult(i);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex.Message);
            }
        }

        /// <summary>
        /// Dodaje clana u bazu
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    POST api/v1/Clan
        ///    {ime:"",br_iskaznice:125}
        ///
        /// </remarks>
        /// <returns>Kreirani clan u bazi sa svim podacima</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="400">Zahtjev nije valjan (BadRequest)</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 
        /// 

        [HttpPost]
        public IActionResult Post(Clan clan)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            try
            {
                _context.Clan.Add(clan);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created, clan);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable,ex.Message);
            }
        }
        /// <summary>
        /// Mijenja podatke postojećeg clana u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    PUT api/v1/clan/1
        ///
        /// {
        ///  "sifra": 0,
        ///  "ime": "",
        ///  "prezime": "Novi naziv",
        ///  "broj iskaznice": 125,
        ///  "status": 1,
        ///  
        /// }
        ///
        /// </remarks>
        /// <param name="Id">Id clana koji se mijenja</param>  
        /// <returns>Svi poslani podaci od clana</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">U bazi ne postoji clan kojega zelimo promijeniti</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 
        [HttpPut]
        public IActionResult Put(int Id_clana,Clan clan)
        {
            if (Id_clana<=0 || clan==null)
            {
                return BadRequest();
            }
            try
            {
                var clanBaza = _context.Clan.Find(Id_clana);
                if (clanBaza==null)
                {
                    return BadRequest();
                }
                clanBaza.Ime=clan.Ime;
                clanBaza.Prezime=clan.Prezime;
                clanBaza.Br_Iskaznice=clan.Br_Iskaznice;
                clanBaza.Status=clan.Status;

                _context.Clan.Update(clanBaza);
                _context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, clanBaza);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex);


            }
        }
        /// <summary>
        /// Briše clana iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    DELETE api/v1/clan/1
        ///    
        /// </remarks>
        /// <param name="Id">Id smjera koji se briše</param>  
        /// <returns>Odgovor da li je obrisano ili ne</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">U bazi ne postoji clan kojeg zelimo obrisati</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 

        [HttpDelete]
        
        [Produces("application/json")]
        public IActionResult Delete(int Id_clana)
        {
            if (Id_clana <= 0)
            {
                return BadRequest();
            }

            var clanBaza = _context.Clan.Find(Id_clana);
            if (clanBaza == null)
            {
                return BadRequest();
            }

            try
            {
                _context.Clan.Remove(clanBaza);
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
