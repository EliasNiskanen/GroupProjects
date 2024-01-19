using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleApi.Data;
using PeopleLib;



//Täällä matkojen Controlleri --> Katso luokka RentalInstrument.cs

namespace PeopleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalInstrumentController : ControllerBase
    {
        private readonly ILogger<RentalInstrumentController> _logger;
        private readonly PeopleContext _db;

        public RentalInstrumentController(ILogger<RentalInstrumentController> logger, PeopleContext context)
        {
            _logger = logger;
            _db = context;
        }

        [HttpGet]
        public async Task<IEnumerable<RentalInstrument>> Get()
        {
            //Palauttaa kaiken datan 'Instrument' taulusta
            return await _db.RentalInstruments.ToListAsync();
        }

        //Käyttäjän omien soittimien haku
        [HttpGet("{Id:int}")]
        public async Task<IEnumerable<RentalInstrument>> Get(int Id)
        {
            return await _db.RentalInstruments.Where(t => t.IdRenter == Id).ToArrayAsync();
        }

		//Yhden soittimen haku soittimen ID:llä.

		[HttpGet("getinstrument/{Id:int}")]
		public async Task<ActionResult<RentalInstrument>> GetInstrument(int Id)
		{
            var instrument = await _db.RentalInstruments.FirstOrDefaultAsync(r => r.IdRentalInstrument == Id);

            if (instrument == null)
            {
                return NotFound();
            }

            return instrument;
		}


		[HttpGet("update/{Id:int}")]
        public async Task<ActionResult<RentalInstrument>> GetRentalInstrument(int Id)
        {
            var rentalinstrument = await _db.RentalInstruments.FirstOrDefaultAsync(h => h.IdRentalInstrument == Id);
            if (rentalinstrument == null)
            {
                return NotFound();
            }
            else
            {
                return rentalinstrument;
            }

        }

        //Käyttäjän soittimien muokkaus
        [HttpPut("{id}")]
        public ActionResult Edit(int id, RentalInstrument rentalinstrument)
        {
            if (!InstrumentExists(id))
            {
                return NotFound();
            }
            if (rentalinstrument.Picture == null)
            {
                rentalinstrument.Picture = new byte[] { };
            }
            if (rentalinstrument.IdRentalInstrument == null || rentalinstrument.Model == null)
            {
                return BadRequest();
            }
            else
            {
                _db.Update(rentalinstrument);
                _db.SaveChanges();
                //return RedirectToAction(nameof(Index));
                return Ok();
            }
        }

        private bool InstrumentExists(int id)
        {
            return _db.RentalInstruments.Any(e => e.IdRentalInstrument == id);
        }


        // Soittimen lisäys
        [HttpPost]
        public async Task<IActionResult> Create(RentalInstrument newRentalInstrument)
        {
            if (newRentalInstrument.Picture == null)
            {
                newRentalInstrument.Picture = new byte[] { }; //Tämä voi aiheuttaa kiusaa jos kuvaa ei anneta soitinta luodessa
            }
            if (newRentalInstrument.Model == null)
            {
                newRentalInstrument.Model = "Soittimen malli";
            }

            _db.RentalInstruments.Add(newRentalInstrument);
            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstrument(int id)
        {
            var rentalinstrument = await _db.RentalInstruments.FindAsync(id);
            if (rentalinstrument == null)
            {
                return NotFound();
            }

            _db.RentalInstruments.Remove(rentalinstrument);
            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
