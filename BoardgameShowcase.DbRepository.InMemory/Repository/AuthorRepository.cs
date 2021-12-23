using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.DbRepository.Repository;
using BoardgameShowcase.Model.Entity;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.DbRepository.InMemory.Repository
{
    class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ILogger<AuthorRepository> logger)
            : base(logger)
        {
        }

        protected override Author CloneEntity(Author entity)
        {
            return new()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        public Task<IEnumerable<Author>> FindByNameAsync(string namePart)
        {
            Logger.LogMethodCall(namePart);

            IEnumerable<Author> matchingAuthors = Entities.Where(x => x.Name.Contains(namePart, StringComparison.InvariantCultureIgnoreCase));
            IEnumerable<Author> authors = CloneEntities(matchingAuthors);

            return Task.FromResult(authors);
        }
    }
}
