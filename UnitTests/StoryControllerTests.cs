using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using PeopleApi.Controllers;
using PeopleApi.Data;
using PeopleLib;

namespace UnitTests
{
    public class StoryControllerTests
    {
        private readonly ILogger<StoryController> _logger = new Mock<ILogger<StoryController>>().Object;

        [Fact]
        public async Task Get_ReturnsAllStories()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PeopleContext>()
                .UseInMemoryDatabase(databaseName: "Get_ReturnsAllStories")
                .Options;

            using (var context = new PeopleContext(options))
            {
                var stories = new List<Story>
            {
                new Story { IdStory = 1, StoryText = "Story 1" },
                new Story { IdStory = 2, StoryText = "Story 2" },
                new Story { IdStory = 3, StoryText = "Story 3" },
            };
                context.Stories.AddRange(stories);
                await context.SaveChangesAsync();

                var controller = new StoryController(_logger, context);

                // Act
                var result = await controller.Get();

                // Assert
                Assert.Equal(3, result.Count());
            }
        }

        [Fact]
        public async Task Create_AddsNewStory()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PeopleContext>()
                .UseInMemoryDatabase(databaseName: "Create_AddsNewStory")
                .Options;

            using (var context = new PeopleContext(options))
            {
                var controller = new StoryController(_logger, context);

                var newStory = new Story
                {
                    StoryText = "Test Story",
                    Date = DateTime.Today,
                    IdTravelDestination = 1
                };

                // Act
                var result = await controller.Create(newStory);

                // Assert
                Assert.IsType<OkResult>(result);

                var storyInDb = await context.Stories.FirstOrDefaultAsync(s => s.StoryText == "Test Story");
                Assert.NotNull(storyInDb);
                Assert.Equal(DateTime.Today, storyInDb.Date);
                Assert.Equal(1, storyInDb.IdTravelDestination);
            }
        }

        [Fact]
        public async Task Update_ModifiesExistingStory()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PeopleContext>()
                .UseInMemoryDatabase(databaseName: "Update_ModifiesExistingStory")
                .Options;

            using (var context = new PeopleContext(options))
            {
                var stories = new List<Story>
            {
                new Story { IdStory = 1, StoryText = "Original Story", IdHiker = 1 },
                new Story { IdStory = 2, StoryText = "Another Story", IdHiker = 2 },
            };
                context.Stories.AddRange(stories);
                await context.SaveChangesAsync();

                var controller = new StoryController(_logger, context);

                var updatedStory = new Story
                {
                    IdStory = 1,
                    StoryText = "Updated Story",
                    IdHiker = 3
                };

                // Act
                var result = await controller.Update(1, updatedStory);

                // Assert
                Assert.IsType<OkResult>(result);

                var storyInDb = await context.Stories.FindAsync(1);
                Assert.NotNull(storyInDb);
                Assert.Equal("Updated Story", storyInDb.StoryText);
                Assert.Equal(3, storyInDb.IdHiker);
            }
        }
    }
}
