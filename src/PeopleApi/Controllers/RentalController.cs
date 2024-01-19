using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleApi.Data;
using PeopleLib;


//Täällä tarinoiden Controlleri --> Katso luokka Rental.cs

namespace PeopleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly ILogger<RentalController> _logger;
        private readonly PeopleContext _db;

        public RentalController(ILogger<RentalController> logger, PeopleContext context)
        {
            _logger = logger;
            _db = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Rental>> Get()
        {
            //Palauttaa kaikki vuokraukset 'Rental' taulusta
            return await _db.Rentals.ToListAsync();
        }

        //Vuokrauksen haku soittimen ID:llä
		[HttpGet("{Id:int}")]
		public async Task<ActionResult<Rental>> GetRental(int Id)
		{
			var rental = await _db.Rentals.FirstOrDefaultAsync(r => r.IdRentalinstrument == Id);

			if (rental == null)
			{
				return NotFound();
			}

			return rental;
		}


        //Käyttjäjän lainaamat soittimet ID:llä
        [HttpGet("customer/{Id:int}")]
        public async Task<ActionResult<Rental>> GetRentalCustomer(int Id)
        {
            var rental = await _db.Rentals.FirstOrDefaultAsync(r => r.IdCustomer == Id);

            if (rental == null)
            {
                return NotFound();
            }

            return rental;
        }

        //Käyttjäjän lainaamat soittimet ID:llä
        [HttpGet("renteri/{Id:int}")]
        public async Task<ActionResult<Rental>> GetRenteri(int Id)
        {
            var rental = await _db.Rentals.FirstOrDefaultAsync(r => r.IdRenter == Id);

            if (rental == null)
            {
                return NotFound();
            }

            return rental;
        }

        //Vuokrauksen lisäys
        [HttpPost]
        public async Task<IActionResult> Create(Rental newRental)
        {
            //newRental.Rentalstart = DateTime.Today;
            //newRental.IdRentalinstrument = 1;

            if (newRental.RentalText == null || newRental.RentalText == "")
            {
                newRental.RentalText = "Vuokrauksen oletusteksti";
            }

            _db.Rentals.Add(newRental);
            await _db.SaveChangesAsync();

            return Ok();
        }

        //Vuokrauksen muokkaus
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Rental model)
        {
            var Rental = await _db.Rentals.FindAsync(id);
            if (null == Rental)
            {
                return NotFound();
            }
            Rental.RentalText = model.RentalText;
            Rental.IdRental = model.IdRental;

            await _db.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRental(int id)
        {
            var Rental = await _db.Rentals.FirstOrDefaultAsync(s => s.IdRental == id);
            if (Rental == null)
            {
                return NotFound();
            }

            var pictures = await _db.RentalPictures.Where(sp => sp.IdRental == Rental.IdRental).ToListAsync();
            foreach (var picture in pictures)
            {
                _db.RentalPictures.Remove(picture);
            }

            _db.Rentals.Remove(Rental);
            await _db.SaveChangesAsync();

            return Ok();
        }

    }
}
