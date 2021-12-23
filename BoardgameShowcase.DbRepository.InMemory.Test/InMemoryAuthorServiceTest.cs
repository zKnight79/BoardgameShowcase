using BoardgameShowcase.DbRepository.InMemory.Test.Extensions;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using Xunit;

namespace BoardgameShowcase.DbRepository.InMemory.Test
{
    public class InMemoryAuthorServiceTest
    {
        private readonly IAuthorService _authorService;

        public InMemoryAuthorServiceTest(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [Fact]
        public async Task GetAllTest()
        {
            IEnumerable<Author> authors = await _authorService.GetAllAsync();
            Assert.Equal(6, authors.Count());
        }

        [Theory]
        [InlineData("31709d7cb6b743adb35c9546bef3fdee", true, "Antoine Bauza")]
        [InlineData("bdf144204fb3476aa9094f9ac5cd7112", true, "Jacob Fryxelius")]
        [InlineData("5bf7883e49a14abebc81b38bcdcec866", true, "Jamey Stegmaier")]
        [InlineData("1e5e9bb7d5c84bc596f73488f9c6a19c", true, "Richard Garfield")]
        [InlineData("eb895b1f1a054b458471972587d51dc3", true, "Alan R. Moon")]
        [InlineData("294fb4abf5d94d93b21aebff08998b3d", true, "Michael Kiesling")]
        [InlineData("40d3e8d3fc264fa2861d4f47994d845b", false, null)]
        [InlineData("2b76f7e6e18746a9853a662236228de7", false, null)]
        public async Task GetByIdTest(string authorId, bool shouldFind, string expectedName)
        {
            Author? author = await _authorService.GetByIdAsync(authorId);
            Assert.Equal(shouldFind, author is not null);
            Assert.Equal(expectedName, author?.Name);
        }

        [Theory]
        [InlineData("azerty")]
        [InlineData("li", "bdf144204fb3476aa9094f9ac5cd7112", "294fb4abf5d94d93b21aebff08998b3d")]
        [InlineData("bauz", "31709d7cb6b743adb35c9546bef3fdee")]
        [InlineData("icha", "1e5e9bb7d5c84bc596f73488f9c6a19c", "294fb4abf5d94d93b21aebff08998b3d")]
        public async Task GetByNameTest(string namePart, params string[] authorIds)
        {
            IEnumerable<Author> authors = await _authorService.GetByNameAsync(namePart);
            AssertExtensions.EntitiesMatch(authorIds, authors);
        }

        [Fact]
        public async Task AddModifiyAndRemoveTest()
        {
            Author author = new()
            {
                Name = "Eric M. Lang"
            };
            Author? addedAuthor = await _authorService.SaveAsync(author);
            Assert.NotNull(addedAuthor);
            IEnumerable<Author> authorsAfterAdd = await _authorService.GetAllAsync();
            Assert.Equal(7, authorsAfterAdd.Count());
            if (addedAuthor is not null)
            {
                addedAuthor.Name = "Cole Wehrle";
                Author? modifiedAuthor = await _authorService.SaveAsync(addedAuthor);
                Assert.NotNull(modifiedAuthor);
                IEnumerable<Author> authorsAfterUpdate = await _authorService.GetAllAsync();
                Assert.Equal(7, authorsAfterUpdate.Count());
                if (modifiedAuthor is not null)
                {
                    Assert.Equal(addedAuthor, modifiedAuthor);
                    Assert.Equal(addedAuthor.Name, modifiedAuthor.Name);
                    Author? removedAuthor = await _authorService.RemoveAsync(modifiedAuthor);
                    Assert.NotNull(removedAuthor);
                    Assert.Equal(modifiedAuthor, removedAuthor);
                    IEnumerable<Author> authorsAfterRemove = await _authorService.GetAllAsync();
                    Assert.Equal(6, authorsAfterRemove.Count());
                }
            }
        }
    }
}