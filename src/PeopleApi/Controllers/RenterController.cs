using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleApi.Data;
using PeopleLib;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;


//Täällä Matkaajien/kulkijoiden Controlleri --> Katso luokka Renter.cs

namespace PeopleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RenterController : ControllerBase
    {
        private readonly ILogger<RenterController> _logger;
        private readonly PeopleContext _db;

        public RenterController(ILogger<RenterController> logger, PeopleContext context)
        {
            _logger = logger;
            _db = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Renter>> Get()
        {
            //Palauttaa kaiken datan 'Renter' taulusta
            return await _db.Renters.ToListAsync();
        }

        // Tarkistetaan rekisteröitymisen yhteydessä onko käyttäjän antama sähköposti jo olemassa   
        //TODO Palauta vain statuskoodi tai vastaava jonka perusteella tehdään clientin päässä ratkaisu miten edetään
        // Ei ole mitään järkeä liikutella tietoa olion mukana
        [HttpGet("register/{email}")]
        public async Task<Renter> GetRenterEmail(string email)
        {
            var Renter = await _db.Renters.FirstOrDefaultAsync(h => h.Email == email);
            if (Renter == null) //Sähköpostia ei ole olemassa --> Voidaan siis luoda uusi tunnus
            {
                Renter newRenter = new Renter();
                newRenter.Presentation = "Ok";
                return newRenter;
            }
            else
            {
                Renter.Presentation = "Sähköposti jo olemassa";
                return Renter;
            }

        }

        //Kirjautuminen palveluun / yhden käyttäjän hakeminen muuten alla olevilla parametreilla
        //TODO Palauta vain statuskoodi tai vastaava jonka perusteella tehdään clientin päässä ratkaisu miten edetään
        // Ei ole mitään järkeä liikutella tietoa olion mukana
        [HttpGet("login/{email}/{password}")]
        public async Task<Renter> GetLoginUser(string email, string password)
        {
            var Renter = await _db.Renters.FirstOrDefaultAsync(h => h.Email == email && h.Password == password);
            if (Renter == null)
            {
                Renter RenterError = new Renter();
                RenterError.Presentation = "Error msg: Salasana ja sähköpostiosoite eivät täsmää";
                return RenterError;
            }
            else
            {
                return Renter;
            }
        }

        //Käyttäjän tietojen haku 
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<Renter>> GetRenter(int Id)
        {
            var Renter = await _db.Renters.FirstOrDefaultAsync(h => h.IdRenter == Id);
            if (Renter == null)
            {
                return NotFound();
            }
            else
            {
                return Renter;
            }

        }

        //käyttäjän tietojen muokkaus
        [HttpPut("{id}")]
        public ActionResult Edit(int id, Renter Renter)
        {
            if (!RenterExists(id))
            {
                return NotFound();
            }
            if (Renter.Picture == null)
            {
                Renter.Picture = new byte[] { };
            }
            if (Renter.FirstName == null || Renter.LastName == null || Renter.NickName == null || Renter.Email == null || Renter.Password == null)
            {
                return BadRequest();
            }
            else
            {
                Console.WriteLine(Renter.IdRenter+Renter.LastName + Renter.NickName+ Renter.FirstName+Renter.Email+Renter.Password+Renter.Locality+Renter.Presentation);
                _db.Update(Renter);
                _db.SaveChanges();
                //return RedirectToAction(nameof(Index));
                return Ok();
            }
        }

        private bool RenterExists(int id)
        {
            return _db.Renters.Any(e => e.IdRenter == id);
        }



        // Matkaajan lisäys (rekisteröityminen)
        [HttpPost]
        public async Task<IActionResult> Create(Renter model)
        {
            model.Locality = "Testipaikka";
            model.Presentation = "Esittely";
            if (model.Picture == null)
            {
                model.Picture = null; //Mikäs idea tässä tässä on?
            }
            _db.Renters.Add(model);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
