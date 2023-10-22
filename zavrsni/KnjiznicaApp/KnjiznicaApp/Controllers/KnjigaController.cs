using KnjiznicaApp.Data;
using KnjiznicaApp.Models;
using Microsoft.AspNetCore.Mvc;
using KnjiznicaApp.Models.DTO;
using Microsoft.EntityFrameworkCore;
namespace KnjiznicaApp.Controllers
{

    /// <summary>
    /// Namijenjeno za CRUD operacije na entitetu knjiga u bazi
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class KnjigaController : ControllerBase
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
            try
            {
                var knjige = _context.Knjiga.ToList();
                if (knjige == null || knjige.Count == 0)
                {
                    return new EmptyResult();
                }
                List<KnjigaDTO> vrati = new();
                var ds = Path.DirectorySeparatorChar;
                string dir = Path.Combine(Directory.GetCurrentDirectory() + ds + "wwwroot" + ds + "slike" + ds + "knjige" + ds);

                knjige.ForEach(k =>
                {
                    var dto = new KnjigaDTO();
                    var putanja = "/slike/prazno.png";
                    if (System.IO.File.Exists(dir + k.Id_knjige + ".png"))
                    {
                        putanja = "/slike/knjige/" + k.Id_knjige + ".png";
                    }

                    vrati.Add(new KnjigaDTO
                    {
                        Id_knjige = k.Id_knjige,
                        Naslov = k.Naslov,
                        Ime_Autora = k.Ime_Autora,
                        Prezime_Autora = k.Prezime_Autora,
                        Sazetak = k.Sazetak,
                        Br_stranica = k.Br_stranica,
                        Slika = putanja
                    });



                });
                return new JsonResult(vrati);
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status503ServiceUnavailable, e.Message); //204
            }
           

        }

        [HttpGet]
        [Route("{id_knjige:int}")]
        public IActionResult GetByID(int id_knjige)
        {
            if (id_knjige <= 0)
            {
                return BadRequest(ModelState);
            }
            var i = _context.Knjiga.Find(id_knjige);
            if (i == null)
            {
                return StatusCode(StatusCodes.Status204NoContent, i);

            }
            try
            {
                var ds = Path.DirectorySeparatorChar;
                string dir = Path.Combine(Directory.GetCurrentDirectory()
                    + ds + "wwwroot" + ds + "slike" + ds + "knjige" + ds);
                var putanja = "/slike/prazno.png";
                if (System.IO.File.Exists(dir + i.Id_knjige + ".png"))
                {
                    putanja = "/slike/knjige/" + i.Id_knjige + ".png";
                }

                var dto = new KnjigaDTO()
                {
                    Id_knjige=i.Id_knjige,
                    Naslov=i.Naslov,
                    Ime_Autora=i.Ime_Autora,
                    Prezime_Autora=i.Prezime_Autora,
                    Sazetak=i.Sazetak,
                    Br_stranica=i.Br_stranica,
                    Slika=putanja
                };
                return new JsonResult(dto);
              
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
            if (Id_knjige <= 0 || dto == null)
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
                knjigaBaza.Ime_Autora = dto.Ime_Autora;
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
            if (Id_knjige <= 0)
            {
                return BadRequest();
            }
            var knjigaBaza = _context.Knjiga.Find(Id_knjige);
            if (knjigaBaza == null)
            {
                return BadRequest();
            }
            try
            {
                _context.Knjiga.Remove(knjigaBaza);
                _context.SaveChanges();

                return new JsonResult("{\"poruka\":\"Obrisano\"}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status406NotAcceptable, "Ne može se obrisati, polaznik se nalazi na nekoj grupi");
            }
        }

        /// <summary>
        /// Postavlja sliku polaznika na server
        /// </summary>
        /// <remarks>
        /// Primjer upita:
        ///
        ///    PUT api/v1/knjiga/postaviSliku/1
        ///
        ///     "BASE64 string knjige"
        ///    
        /// </remarks>
        /// <param name="Id_knjige">ID knjige za koji se postavlja slika</param>  
        /// <returns>Poruku o uspješnosti pohrane slike na server</returns>
        /// <response code="200">Sve je u redu</response>
        /// <response code="204">Nema u bazi knjige za postaviti sliku</response>
        /// <response code="503">Na azure treba dodati IP u firewall</response> 
        [HttpPut]
        [Route("postaviSliku/{id_knjige:int}")]
        public IActionResult PostaviSliku(int Id_knjige, SlikaDTO slikaDTO)
        {
            if (Id_knjige == 0)
            {
                return BadRequest(); //400
            }

            if (slikaDTO == null || slikaDTO?.Base64?.Length == 0)
            {
                return BadRequest(); //400
            }

            var p = _context.Knjiga.Find(Id_knjige);
            if (p == null)
            {
                return BadRequest(); //400
            }



            try
            {
                var ds = Path.DirectorySeparatorChar;




                string dir = Path.Combine(Directory.GetCurrentDirectory()
                    + ds + "wwwroot" + ds + "slike" + ds + "knjige");


                if (!System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.CreateDirectory(dir);
                }


                var putanja = Path.Combine(dir + ds + Id_knjige + ".png");



                System.IO.File.WriteAllBytes(putanja, Convert.FromBase64String(slikaDTO?.Base64));

                return new JsonResult("{\"poruka\": \"Uspješno pohranjena slika\"}");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, e.Message); //204
            }
        }





    }
}




