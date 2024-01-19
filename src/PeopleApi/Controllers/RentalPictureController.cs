using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleApi.Data;
using PeopleLib;

//Täällä tarinoiden kuvien Controlleri --> Katso luokka RentalPicture.cs

namespace PeopleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalPictureController : ControllerBase
    {
        private readonly ILogger<RentalPictureController> _logger;
        private readonly PeopleContext _db;

        public RentalPictureController(ILogger<RentalPictureController> logger, PeopleContext context)
        {
            _logger = logger;
            _db = context;
        }

        [HttpGet]
        public async Task<IEnumerable<RentalPicture>> Get()
        {
            //Palauttaa kaikki kuvat 'RentalPicture' taulusta
            return await _db.RentalPictures.ToListAsync();
        }

        //Tarinan lisäys matkalle
        [HttpPost]
        public async Task<IActionResult> Create(RentalPicture newRentalPicture)
        {

            if (newRentalPicture.Picture == null)
            {
                newRentalPicture.Picture = new byte[] { }; //Tämä voi aiheuttaa kiusaa jos kuvaa ei anneta tarinaa luodessa
            }

            _db.RentalPictures.Add(newRentalPicture);
            await _db.SaveChangesAsync();

            return Ok();
        }
    }
}
