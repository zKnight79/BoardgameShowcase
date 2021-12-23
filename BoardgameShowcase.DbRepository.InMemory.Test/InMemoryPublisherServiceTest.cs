using BoardgameShowcase.DbRepository.InMemory.Test.Extensions;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using Xunit;

namespace BoardgameShowcase.DbRepository.InMemory.Test
{
    public class InMemoryPublisherServiceTest
    {
        private readonly IPublisherService _publisherService;

        public InMemoryPublisherServiceTest(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [Fact]
        public async Task GetAllTest()
        {
            IEnumerable<Publisher> publishers = await _publisherService.GetAllAsync();
            Assert.Equal(6, publishers.Count());
        }

        [Theory]
        [InlineData("650f72f3274849099d4265ccbeefc64f", true, "Repos Production")]
        [InlineData("f80820ac1f0c4017a0c1fba2b3d263b5", true, "Intrafin")]
        [InlineData("ebaa178eabf642a59f31a5e27a5be566", true, "Matagot")]
        [InlineData("77dc41e600a241e1850fe71f2da9d0a6", true, "Iello")]
        [InlineData("3ceb6ddd724543c786a654e7c5a1d13e", true, "Days of Wonder")]
        [InlineData("43ea31d0b8764517b78d686d66647d29", true, "Next Move")]
        [InlineData("40d3e8d3fc264fa2861d4f47994d845b", false, null)]
        [InlineData("2b76f7e6e18746a9853a662236228de7", false, null)]
        public async Task GetByIdTest(string publisherId, bool shouldFind, string expectedName)
        {
            Publisher? publisher = await _publisherService.GetByIdAsync(publisherId);
            Assert.Equal(shouldFind, publisher is not null);
            Assert.Equal(expectedName, publisher?.Name);
        }

        [Theory]
        [InlineData("azerty")]
        [InlineData("s ", "650f72f3274849099d4265ccbeefc64f", "3ceb6ddd724543c786a654e7c5a1d13e")]
        [InlineData("tag", "ebaa178eabf642a59f31a5e27a5be566")]
        [InlineData("on", "650f72f3274849099d4265ccbeefc64f", "3ceb6ddd724543c786a654e7c5a1d13e")]
        public async Task GetByNameTest(string namePart, params string[] publisherIds)
        {
            IEnumerable<Publisher> publishers = await _publisherService.GetByNameAsync(namePart);
            AssertExtensions.EntitiesMatch(publisherIds, publishers);
        }

        [Fact]
        public async Task AddModifiyAndRemoveTest()
        {
            Publisher publisher = new()
            {
                Name = "Edge"
            };
            Publisher? addedPublisher = await _publisherService.SaveAsync(publisher);
            Assert.NotNull(addedPublisher);
            IEnumerable<Publisher> publishersAfterAdd = await _publisherService.GetAllAsync();
            Assert.Equal(7, publishersAfterAdd.Count());
            if (addedPublisher is not null)
            {
                addedPublisher.Name = "Blue Orange";
                Publisher? modifiedPublisher = await _publisherService.SaveAsync(addedPublisher);
                Assert.NotNull(modifiedPublisher);
                IEnumerable<Publisher> publishersAfterUpdate = await _publisherService.GetAllAsync();
                Assert.Equal(7, publishersAfterUpdate.Count());
                if (modifiedPublisher is not null)
                {
                    Assert.Equal(addedPublisher, modifiedPublisher);
                    Assert.Equal(addedPublisher.Name, modifiedPublisher.Name);
                    Publisher? removedPublisher = await _publisherService.RemoveAsync(modifiedPublisher);
                    Assert.NotNull(removedPublisher);
                    Assert.Equal(modifiedPublisher, removedPublisher);
                    IEnumerable<Publisher> publishersAfterRemove = await _publisherService.GetAllAsync();
                    Assert.Equal(6, publishersAfterRemove.Count());
                }
            }
        }
    }
}