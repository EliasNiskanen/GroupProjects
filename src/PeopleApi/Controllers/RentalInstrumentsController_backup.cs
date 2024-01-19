//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using PeopleApi.Data;
//using PeopleLib;

//namespace PeopleApi.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class RentalInstrumentController : ControllerBase
//    {
//        private readonly ILogger<RentalInstrumentController> _logger;
//        private readonly PeopleContext _db;

//        public RentalInstrumentController(ILogger<RentalInstrumentController> logger, PeopleContext context)
//        {
//            _logger = logger;
//            _db = context;
//        }

//        [HttpGet]
//        public async Task<IEnumerable<RentalInstrument>> Get()
//        {
//            //Palauttaa kaikki 'RentalInstruments' taulussa olevat rivit
//            return await _db.RentalInstruments.ToListAsync();
//        }

//        [HttpPost]

//        //Kohteen Lisäys
//        public async Task<IActionResult> Create(RentalInstrument model)
//        {

//            if (model.Picture == null)
//            {
//                model.Picture = new byte[] { }; //Jos kuvaa ei anneta
//            }

//            _db.RentalInstruments.Add(model);
//            await _db.SaveChangesAsync();

//            return Ok();
//        }






//        //Kohteen muokkaus
//        [HttpPut("{id}")]
//        public async Task<IActionResult> Update(int id, RentalInstrument model)
//        {
//            var RentalInstrument = await _db.RentalInstruments.FindAsync(id);
//            if (null == RentalInstrument)
//            {
//                return NotFound();
//            }
//            // RentalInstrument.IdRentalInstrument = model.IdRentalInstrument;
//            RentalInstrument.Model = model.Model;
//            RentalInstrument.Brand = model.Brand;
//            RentalInstrument.Price = model.Price;
//            RentalInstrument.InstrumentInfo = model.InstrumentInfo;
//            RentalInstrument.ModelYear = model.ModelYear;
//            RentalInstrument.Picture = model.Picture;


//            await _db.SaveChangesAsync();

//            return Ok();
//        }


//    }
//}
