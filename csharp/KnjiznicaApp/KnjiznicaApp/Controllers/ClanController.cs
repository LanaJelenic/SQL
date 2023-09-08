using KnjiznicaApp.Data;
using KnjiznicaApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
namespace KnjiznicaApp.Controllers
{
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
        /// Dohvaća sve clanove iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    GET api/v1/Clan
        ///
        /// </remarks>
        /// <returns>Clanovi u bazi</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="400">Zahtjev nije valjan (BadRequest)</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 

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
        /// Mijenja clana u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    PUT api/v1/Clan
        ///    {ime:"",prezime:"Peric"(prijasnje),"Majic"(novo)}
        ///
        /// </remarks>
        /// <returns>Kreirani clan u bazi sa svim podacima</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="400">Zahtjev nije valjan (BadRequest)</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 
        /// 
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
        /// Brise clana iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///   DELETE api/v1/Clan
        ///    {id:int}
        ///
        /// </remarks>
        /// <returns>Izbrisan ID clana iz baze</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="400">Zahtjev nije valjan (BadRequest)</response> 
        /// <response code="503">Na azure treba dodati IP u firewall</response> 
        /// 

        [HttpDelete]
        //[Route("{Id_clana:int}")]
        //[Route("{ID:int}")]
        public IActionResult Delete(int Id_clana) 
        {
        
         if (Id_clana <=0)
            {
               
                return BadRequest();
            }
            Console.WriteLine("Brišem clana : " + Id_clana);
            try
            {
                var clanBaza = _context.Clan.Find(Id_clana);
                Console.WriteLine("Brišem clana : " + clanBaza.Ime + " " + clanBaza.Prezime);

                if (clanBaza==null)
                {
                    return BadRequest();
                }

                _context.Clan.Remove(clanBaza);
                _context.SaveChanges();

                return new JsonResult("Clan uspjesno obrisan!!");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, ex);

            }


        }
    }
}
