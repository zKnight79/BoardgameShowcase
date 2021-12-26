using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Repository.Repository;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.Repository.InMemory.Repository
{
    class IllustratorRepository : GenericRepository<Illustrator>, IIllustratorRepository
    {
        public IllustratorRepository(ILogger<IllustratorRepository> logger, IDataAccess<Illustrator> dataAccess)
            : base(logger, dataAccess)
        {
        }

        public Task<IEnumerable<Illustrator>> FindByNameAsync(string namePart)
        {
            Logger.LogMethodCall(namePart);

            IEnumerable<Illustrator> illustrators = DataAccess.QueryEntities(x => x.Name.Contains(namePart, StringComparison.InvariantCultureIgnoreCase));

            return Task.FromResult(illustrators);
        }
    }
}
