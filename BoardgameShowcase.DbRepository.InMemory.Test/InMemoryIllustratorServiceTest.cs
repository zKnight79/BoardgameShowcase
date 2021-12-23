using BoardgameShowcase.DbRepository.InMemory.Test.Extensions;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using Xunit;

namespace BoardgameShowcase.DbRepository.InMemory.Test
{
    public class InMemoryIllustratorServiceTest
    {
        private readonly IIllustratorService _illustratorService;

        public InMemoryIllustratorServiceTest(IIllustratorService illustratorService)
        {
            _illustratorService = illustratorService;
        }

        [Fact]
        public async Task GetAllTest()
        {
            IEnumerable<Illustrator> illustrators = await _illustratorService.GetAllAsync();
            Assert.Equal(6, illustrators.Count());
        }

        [Theory]
        [InlineData("a48e861f73294ede862408b7a71c3df9", true, "Etienne Hebinger")]
        [InlineData("0c67dd6252e142a8b5b010cdfc3b6dd7", true, "Isaac Fryxelius")]
        [InlineData("714242445ee64533a1eb5b18d71f061b", true, "Jakub Rozalski")]
        [InlineData("b916ee6e523142438ab09ef8ff11780d", true, "Régis Torres")]
        [InlineData("afca2c0c57664311af12ebf09daf70dd", true, "Julien Delval")]
        [InlineData("9d740aea7dbe442d9116fa2aad730222", true, "Chris Quilliams")]
        [InlineData("40d3e8d3fc264fa2861d4f47994d845b", false, null)]
        [InlineData("2b76f7e6e18746a9853a662236228de7", false, null)]
        public async Task GetByIdTest(string illustratorId, bool shouldFind, string expectedName)
        {
            Illustrator? illustrator = await _illustratorService.GetByIdAsync(illustratorId);
            Assert.Equal(shouldFind, illustrator is not null);
            Assert.Equal(expectedName, illustrator?.Name);
        }

        [Theory]
        [InlineData("azerty")]
        [InlineData("li", "0c67dd6252e142a8b5b010cdfc3b6dd7", "afca2c0c57664311af12ebf09daf70dd", "9d740aea7dbe442d9116fa2aad730222")]
        [InlineData("del", "afca2c0c57664311af12ebf09daf70dd")]
        [InlineData("s ", "b916ee6e523142438ab09ef8ff11780d", "9d740aea7dbe442d9116fa2aad730222")]
        public async Task GetByNameTest(string namePart, params string[] illustratorIds)
        {
            IEnumerable<Illustrator> illustrators = await _illustratorService.GetByNameAsync(namePart);
            AssertExtensions.EntitiesMatch(illustratorIds, illustrators);
        }

        [Fact]
        public async Task AddModifiyAndRemoveTest()
        {
            Illustrator illustrator = new()
            {
                Name = "Adrian Smith"
            };
            Illustrator? addedIllustrator = await _illustratorService.SaveAsync(illustrator);
            Assert.NotNull(addedIllustrator);
            IEnumerable<Illustrator> illustratorsAfterAdd = await _illustratorService.GetAllAsync();
            Assert.Equal(7, illustratorsAfterAdd.Count());
            if (addedIllustrator is not null)
            {
                addedIllustrator.Name = "Kyle Ferrin";
                Illustrator? modifiedIllustrator = await _illustratorService.SaveAsync(addedIllustrator);
                Assert.NotNull(modifiedIllustrator);
                IEnumerable<Illustrator> illustratorsAfterUpdate = await _illustratorService.GetAllAsync();
                Assert.Equal(7, illustratorsAfterUpdate.Count());
                if (modifiedIllustrator is not null)
                {
                    Assert.Equal(addedIllustrator, modifiedIllustrator);
                    Assert.Equal(addedIllustrator.Name, modifiedIllustrator.Name);
                    Illustrator? removedIllustrator = await _illustratorService.RemoveAsync(modifiedIllustrator);
                    Assert.NotNull(removedIllustrator);
                    Assert.Equal(modifiedIllustrator, removedIllustrator);
                    IEnumerable<Illustrator> illustratorsAfterRemove = await _illustratorService.GetAllAsync();
                    Assert.Equal(6, illustratorsAfterRemove.Count());
                }
            }
        }
    }
}
