using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.DbRepository.Repository;
using BoardgameShowcase.Model.Entity;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.DbRepository.InMemory.Repository
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
