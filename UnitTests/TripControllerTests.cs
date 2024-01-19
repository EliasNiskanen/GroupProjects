using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using PeopleApi.Controllers;
using PeopleApi.Data;
using PeopleLib;

namespace UnitTests
{
    public class TripControllerTests
    {
        private PeopleContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<PeopleContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var dbContext = new PeopleContext(options);
            return dbContext;
        }


        [Fact]
        public async Task Get_ReturnsAllTrips()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            dbContext.Trips.Add(new Trip { IdHiker = 1, IdTrip = 1, HeadLine = "Matkan 1 otsikko", Picture = null, Private = true, StartDate = DateTime.Parse("12.03.2013"), EndDate = DateTime.Parse("12.03.2016") });
            dbContext.Trips.Add(new Trip { IdHiker = 2, IdTrip = 2, HeadLine = "Matkan 2 otsikko", Picture = null, Private = false, StartDate = DateTime.Parse("25.03.2023"), EndDate = DateTime.Parse("27.03.2023") });
            await dbContext.SaveChangesAsync();

            ILogger<TripController> logger = new NullLogger<TripController>();
            var controller = new TripController(logger, dbContext);

            // Act
            var result = await controller.Get();

            // Assert
            var trips = Assert.IsAssignableFrom<IEnumerable<Trip>>(result);
            Assert.Equal(2, trips.Count());
        }

        [Fact]
        public async Task GetTrip_ReturnsTrip_WhenTripIdExists()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            dbContext.Trips.Add(new Trip { IdHiker = 1, IdTrip = 1, HeadLine = "Matkan otsikko", Picture = null, Private = true, StartDate = DateTime.Parse("12.03.2013"), EndDate = DateTime.Parse("12.03.2016") });
            await dbContext.SaveChangesAsync();

            ILogger<TripController> logger = new NullLogger<TripController>();
            var controller = new TripController(logger, dbContext);

            int id = 1;

            // Act
            var result = await controller.GetTrip(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Trip>(result.Value);
            Assert.Equal(1, result.Value.IdTrip);
            Assert.Equal("Matkan otsikko", result.Value.HeadLine);
        }

        [Fact]
        public async Task GetTrip_ReturnsNotFound_When_TripIdNotExists()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            ILogger<TripController> logger = new NullLogger<TripController>();
            var controller = new TripController(logger, dbContext);

            int id = 1;

            // Act
            var result = await controller.GetTrip(id);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task Edit_ReturnsBadRequest_WhenTripHasMissingFields()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            dbContext.Trips.Add(new Trip { IdHiker = 1, IdTrip = 1, HeadLine = "Matkan otsikko", Picture = null, Private = true, StartDate = DateTime.Parse("12.03.2013"), EndDate = DateTime.Parse("12.03.2016") });
            await dbContext.SaveChangesAsync();

            ILogger<TripController> logger = new NullLogger<TripController>();
            var controller = new TripController(logger, dbContext);

            var updatedTrip = new Trip { IdHiker = 1, IdTrip = 1, HeadLine = null, Picture = null, Private = true, StartDate = DateTime.Parse("12.03.2013"), EndDate = DateTime.Parse("12.03.2016") };

            // Act
            var result = controller.Edit(1, updatedTrip);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Edit_ReturnsOk_WhenTripInfoIsValid()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            dbContext.Trips.Add(new Trip { IdHiker = 1, IdTrip = 1, HeadLine = "Matkan otsikko", Picture = null, Private = true, StartDate = DateTime.Parse("12.03.2013"), EndDate = DateTime.Parse("12.03.2016") });
            await dbContext.SaveChangesAsync();

            ILogger<TripController> logger = new NullLogger<TripController>();
            var controller = new TripController(logger, dbContext);

            var tripFromDb = await dbContext.Trips.FindAsync(1);
            tripFromDb.HeadLine = "Muutettu matkan otsikko";
            tripFromDb.Private = false;
       
            // Act
            var result = controller.Edit(1, tripFromDb);

            // Assert
            Assert.IsType<OkResult>(result);

            // Verify that the trip's information was updated in the database
            var updatedTripFromDb = await dbContext.Trips.FindAsync(1);
            Assert.False(updatedTripFromDb.Private);
            Assert.Equal("Muutettu matkan otsikko", updatedTripFromDb.HeadLine);
        }

        [Fact]
        public async Task Create_ReturnsOk_AndAddsTripToDatabase()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            ILogger<TripController> logger = new NullLogger<TripController>();
            var controller = new TripController(logger, dbContext);

            var newTrip = new Trip
            {
                IdTrip= 666,
                HeadLine = "Matka Jongunjoelle",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today,
                Private = false,
                IdHiker = 1
            };

            // Act
            var result = await controller.Create(newTrip);

            // Assert
            Assert.IsType<OkResult>(result);

            // Verify that the hiker was added to the database
            var tripFromDb = await dbContext.Trips.FirstOrDefaultAsync(h => h.HeadLine == "Matka Jongunjoelle");
            Assert.NotNull(tripFromDb);
            Assert.Equal(DateTime.Today, tripFromDb.StartDate);
            Assert.Equal(DateTime.Today, tripFromDb.EndDate);
            Assert.False(tripFromDb.Private);
        }

        [Fact]
        public async Task DeleteReturnsOk_WhenTripIdFound()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            ILogger<TripController> logger = new NullLogger<TripController>();
            var controller = new TripController(logger, dbContext);

            var newTrip = new Trip
            {
                IdTrip = 987,
                HeadLine = "Matka Jorpakkoon",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today,
                Private = false,
                IdHiker = 1
            };

            // Act
            var result = await controller.Create(newTrip);

            // Assert
           // Assert.IsType<OkResult>(result);

           // Verify that the hiker was added to the database
            var tripFromDb = await dbContext.Trips.FirstOrDefaultAsync(h => h.HeadLine == "Matka Jorpakkoon");
            Assert.NotNull(tripFromDb);
            Assert.Equal(987, tripFromDb.IdTrip);
            Assert.Equal(DateTime.Today, tripFromDb.StartDate);
            Assert.Equal(DateTime.Today, tripFromDb.EndDate);
            Assert.False(tripFromDb.Private);


            // Act
            var resultDelete = controller.DeleteTrip(987);

            var res = await controller.GetTrip(987);

            // Assert
            Assert.IsType<NotFoundResult>(res.Result);
        }

        [Fact]
        public async Task DeleteReturnsNotFound_WhenTripIdNotFound()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            ILogger<TripController> logger = new NullLogger<TripController>();
            var controller = new TripController(logger, dbContext);

            // Act
            var resultDelete = controller.DeleteTrip(DateTime.Now.Month+DateTime.Now.Day+DateTime.Now.Minute+DateTime.Now.Second+DateTime.Now.Millisecond);

            // Assert
            Assert.IsType<NotFoundResult>(resultDelete.Result);
        }
    }
}
