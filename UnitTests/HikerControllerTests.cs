using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using PeopleApi.Controllers;
using PeopleApi.Data;
using PeopleLib;

namespace UnitTests
{
    public class HikerControllerTests
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
        public async Task Get_ReturnsAllHikers()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            dbContext.Hikers.Add(new Hiker { IdHiker = 1, FirstName = "John", LastName = "Doe", NickName = "JD", Email = "john@example.com", Password = "password" });
            dbContext.Hikers.Add(new Hiker { IdHiker = 2, FirstName = "Jane", LastName = "Doe", NickName = "Jenny", Email = "jane@example.com", Password = "password" });
            await dbContext.SaveChangesAsync();

            ILogger<HikerController> logger = new NullLogger<HikerController>();
            var controller = new HikerController(logger, dbContext);

            // Act
            var result = await controller.Get();

            // Assert
            var hikers = Assert.IsAssignableFrom<IEnumerable<Hiker>>(result);
            Assert.Equal(2, hikers.Count());
        }

        [Fact]
        public async Task GetHikerEmail_ReturnsNewHiker_WhenEmailNotExists()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            ILogger<HikerController> logger = new NullLogger<HikerController>();
            var controller = new HikerController(logger, dbContext);

            string email = "nonexistent@example.com";

            // Act
            var result = await controller.GetHikerEmail(email);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.IdHiker);
            Assert.Equal("Ok", result.Presentation);
        }

        [Fact]
        public async Task GetHikerEmail_ReturnsExistingHiker_WhenEmailExists()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            dbContext.Hikers.Add(new Hiker { IdHiker = 1, FirstName = "John", LastName = "Doe", NickName = "JD", Email = "john@example.com", Password = "password" });
            await dbContext.SaveChangesAsync();

            ILogger<HikerController> logger = new NullLogger<HikerController>();
            var controller = new HikerController(logger, dbContext);

            string email = "john@example.com";

            // Act
            var result = await controller.GetHikerEmail(email);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.IdHiker);
            Assert.Equal("Sähköposti jo olemassa", result.Presentation);
        }

        [Fact]
        public async Task GetHiker_ReturnsNotFound_WhenHikerIdNotExists()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            ILogger<HikerController> logger = new NullLogger<HikerController>();
            var controller = new HikerController(logger, dbContext);

            int id = 1;

            // Act
            var result = await controller.GetHiker(id);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetHiker_ReturnsHiker_WhenHikerIdExists()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            dbContext.Hikers.Add(new Hiker { IdHiker = 1, FirstName = "John", LastName = "Doe", NickName = "JD", Email = "john@example.com", Password = "password" });
            await dbContext.SaveChangesAsync();

            ILogger<HikerController> logger = new NullLogger<HikerController>();
            var controller = new HikerController(logger, dbContext);

            int id = 1;

            // Act
            var result = await controller.GetHiker(id);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<Hiker>(result.Value);
            Assert.Equal(1, result.Value.IdHiker);
            Assert.Equal("john@example.com", result.Value.Email);
        }

        [Fact]
        public async Task GetLoginUser_ReturnsErrorHiker_WhenEmailAndPasswordNotMatch()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            dbContext.Hikers.Add(new Hiker { IdHiker = 1, FirstName = "John", LastName = "Doe", NickName = "JD", Email = "john@example.com", Password = "password" });
            await dbContext.SaveChangesAsync();

            ILogger<HikerController> logger = new NullLogger<HikerController>();
            var controller = new HikerController(logger, dbContext);

            string email = "john@example.com";
            string password = "wrong_password";

            // Act
            var result = await controller.GetLoginUser(email, password);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.IdHiker);
            Assert.Equal("Error msg: Salasana ja sähköpostiosoite eivät täsmää", result.Presentation);
        }

        [Fact]
        public async Task GetLoginUser_ReturnsHiker_WhenEmailAndPasswordMatch()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            dbContext.Hikers.Add(new Hiker { IdHiker = 1, FirstName = "John", LastName = "Doe", NickName = "JD", Email = "john@example.com", Password = "password" });
            await dbContext.SaveChangesAsync();

            ILogger<HikerController> logger = new NullLogger<HikerController>();
            var controller = new HikerController(logger, dbContext);

            string email = "john@example.com";
            string password = "password";

            // Act
            var result = await controller.GetLoginUser(email, password);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.IdHiker);
            Assert.Equal("john@example.com", result.Email);
        }

        [Fact]
        public async Task Edit_ReturnsBadRequest_WhenHikerHasMissingFields()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            dbContext.Hikers.Add(new Hiker { IdHiker = 1, FirstName = "John", LastName = "Doe", NickName = "JD", Email = "john@example.com", Password = "password" });
            await dbContext.SaveChangesAsync();

            ILogger<HikerController> logger = new NullLogger<HikerController>();
            var controller = new HikerController(logger, dbContext);

            var updatedHiker = new Hiker { IdHiker = 1, FirstName = "John", LastName = "Doe", NickName = null, Email = "john@example.com", Password = "new_password" };

            // Act
            var result = controller.Edit(1, updatedHiker);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Edit_ReturnsOk_WhenHikerInfoIsValid()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            dbContext.Hikers.Add(new Hiker { IdHiker = 1, FirstName = "John", LastName = "Doe", NickName = "JD", Email = "john@example.com", Password = "password" });
            await dbContext.SaveChangesAsync();

            ILogger<HikerController> logger = new NullLogger<HikerController>();
            var controller = new HikerController(logger, dbContext);

            var hikerFromDb = await dbContext.Hikers.FindAsync(1);
            hikerFromDb.FirstName = "John";
            hikerFromDb.LastName = "Doe";
            hikerFromDb.NickName = "J.D.";
            hikerFromDb.Email = "john@example.com";
            hikerFromDb.Password = "new_password";

            // Act
            var result = controller.Edit(1, hikerFromDb);

            // Assert
            Assert.IsType<OkResult>(result);

            // Verify that the hiker's information was updated in the database
            var updatedHikerFromDb = await dbContext.Hikers.FindAsync(1);
            Assert.Equal("J.D.", updatedHikerFromDb.NickName);
            Assert.Equal("new_password", updatedHikerFromDb.Password);
        }

        [Fact]
        public async Task Create_ReturnsOk_AndAddsHikerToDatabase()
        {
            // Arrange
            var dbContext = GetInMemoryDbContext();
            ILogger<HikerController> logger = new NullLogger<HikerController>();
            var controller = new HikerController(logger, dbContext);

            var newHiker = new Hiker
            {
                FirstName = "Jane",
                LastName = "Doe",
                NickName = "JD",
                Email = "jane@example.com",
                Password = "password"
            };

            // Act
            var result = await controller.Create(newHiker);

            // Assert
            Assert.IsType<OkResult>(result);

            // Verify that the hiker was added to the database
            var hikerFromDb = await dbContext.Hikers.FirstOrDefaultAsync(h => h.Email == "jane@example.com");
            Assert.NotNull(hikerFromDb);
            Assert.Equal("Jane", hikerFromDb.FirstName);
            Assert.Equal("Doe", hikerFromDb.LastName);
            Assert.Equal("Testipaikka", hikerFromDb.Locality);
            Assert.Equal("Esittely", hikerFromDb.Presentation);
        }
    }
}