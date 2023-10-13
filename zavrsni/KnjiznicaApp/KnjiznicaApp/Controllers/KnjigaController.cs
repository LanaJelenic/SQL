using KnjiznicaApp.Data;
using KnjiznicaApp.Models;
using Microsoft.AspNetCore.Mvc;
using KnjiznicaApp.Models.DTO;
namespace KnjiznicaApp.Controllers
{

    /// <summary>
    /// Namijenjeno za CRUD operacije na entitetu knjiga u bazi
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class KnjigaController:ControllerBase
    {
        private readonly KnjiznicaContext _context;
        public KnjigaController(KnjiznicaContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Dohvaća sve knjige koje su pohranjene u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    GET api/v1/Knjiga
        ///
        /// </remarks>
        /// <returns>Knjige u bazi</returns>
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
            var knjige = _context.Knjiga.ToList();
            if (knjige==null ||   knjige.Count == 0)
            {
                return new EmptyResult();
            }
            List<KnjigaDTO> vrati = new();

            knjige.ForEach (k =>
                {
                    var dto = new KnjigaDTO()
                    {
                        Id_knjige = k.Id_knjige,
                        Naslov = k.Naslov,
                        Ime_Autora = k.Ime_Autora,
                        Prezime_Autora = k.Prezime_Autora,
                        Sazetak = k.Sazetak,
                        Br_stranica = k.Br_stranica
                    };
                    vrati.Add(dto);


                }) ;
            return Ok(vrati);
            
        }

        [HttpGet]
        [Route("{id_knjige:int}")]
        public IActionResult GetByID(int id_knjige)
        {
            if (id_knjige<=0)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var i = _context.Knjiga.Find(id_knjige);
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
        /// Unosi novu knjigu u bazu podataka
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    POST api/v1/Knjiga
        ///    {Naslov:"",br_stranica:125}
        ///
        /// </remarks>
        /// <returns>Knjiga je uspjesno kreirana</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="400">Zahtjev nije valjan (BadRequest)</response> 
        /// <response code="503">Error na serveru</response> 
        [HttpPost]
        public IActionResult Post(KnjigaDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Knjiga k = new Knjiga()
                {
                    Naslov = dto.Naslov,
                    Ime_Autora = dto.Ime_Autora,
                    Prezime_Autora = dto.Prezime_Autora,
                    Sazetak = dto.Sazetak,
                    Br_stranica = dto.Br_stranica
                };
                _context.Knjiga.Add(k);
                _context.SaveChanges();
                dto.Id_knjige = k.Id_knjige;

                return Ok(dto);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.
                    Status503ServiceUnavailable, ex.Message);
            }
        }
        /// <summary>
        /// Mijenja podatke postojeće knjige u bazi
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    PUT api/v1/knjiga/1
        ///
        /// {
        ///  "sifra": 0,
        ///  "naslov": "",
        ///  "ime_autora": "Novi naziv",
        ///  "broj_stranica": 125,
        ///  
        ///  
        /// }
        ///
        /// </remarks>
        /// <param name="Id">Id knjige koja se mijenja</param>  
        /// <returns>Svi poslani podaci knjige</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">U bazi ne postoji knjiga koju zelimo promijeniti</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Error u serveru</response> 
        [HttpPut]
       
        public IActionResult Put(int Id_knjige, KnjigaDTO dto)
        {
            if (Id_knjige <= 0 || dto== null)
            {
                return BadRequest();
            }
            try
            {
                var knjigaBaza = _context.Knjiga.Find(Id_knjige);
                if (knjigaBaza == null)
                {
                    return BadRequest();
                }
                knjigaBaza.Naslov = dto.Naslov;
                knjigaBaza.Ime_Autora=dto.Ime_Autora;
                knjigaBaza.Prezime_Autora = dto.Prezime_Autora;
                knjigaBaza.Sazetak = dto.Sazetak;
                knjigaBaza.Br_stranica = dto.Br_stranica;

                _context.Knjiga.Update(knjigaBaza);
                _context.SaveChanges();
                dto.Id_knjige = knjigaBaza.Id_knjige;

                return StatusCode(StatusCodes.Status200OK, dto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.
                    Status503ServiceUnavailable, ex);


            }
        }
        /// <summary>
        /// Briše knjigu iz baze
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    DELETE api/v1/knjiga/1
        ///    
        /// </remarks>
        /// <param name="Id">Id knjige koju zelimo obrisati</param>  
        /// <returns>Odgovor da li je obrisano ili ne</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">U bazi ne postoji knjiga koju zelimo obrisati</response>
        /// <response code="415">Nismo poslali JSON</response> 
        /// <response code="503">Error na serveru</response> 
        [HttpDelete]
        [Produces("application/json")]
        public IActionResult Delete(int Id_knjige)
        {
            if (Id_knjige<=0)
            {
                return BadRequest();
            }
            var knjigaBaza = _context.Knjiga.Find(Id_knjige);
            if (knjigaBaza==null)
            {
                return BadRequest();
            }
            try
            {
                _context.Knjiga.Remove(knjigaBaza);
                _context.SaveChanges();

                return  new JsonResult("{\"poruka\":\"Obrisano\"}");
            }
            catch (Exception ex)
            {

                return new JsonResult("{\"poruka\":\"Ne može se obrisati\"}");

            }
        }
    }


}
