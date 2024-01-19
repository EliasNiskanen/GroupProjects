using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeopleApi.Data;
using PeopleLib;

//Täällä oletus profiili kuvien Controlleri --> Katso luokka ProfileDefaultPicture.cs

namespace PeopleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileDefaultPictureController : ControllerBase
    {
        private readonly ILogger<ProfileDefaultPictureController> _logger;
        private readonly PeopleContext _db;

        public ProfileDefaultPictureController(ILogger<ProfileDefaultPictureController> logger, PeopleContext context)
        {
            _logger = logger;
            _db = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ProfileDefaultPicture>> Get()
        {
            //Palauttaa kaikki kuvat 'ProfileDefaultPicture' taulusta
            return await _db.ProfileDefaultPictures.ToListAsync();
        }


    }
}
