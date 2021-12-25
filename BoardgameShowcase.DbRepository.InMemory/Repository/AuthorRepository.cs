using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.DbRepository.Repository;
using BoardgameShowcase.Model.Entity;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.DbRepository.InMemory.Repository
{
    class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ILogger<AuthorRepository> logger, IDataAccess<Author> dataAccess)
            : base(logger, dataAccess)
        {
        }

        public Task<IEnumerable<Author>> FindByNameAsync(string namePart)
        {
            Logger.LogMethodCall(namePart);

            IEnumerable<Author> authors = DataAccess.QueryEntities(x => x.Name.Contains(namePart, StringComparison.InvariantCultureIgnoreCase));

            return Task.FromResult(authors);
        }
    }
}
