using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.DbRepository.Repository;
using BoardgameShowcase.Model.Entity;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.DbRepository.InMemory.Repository
{
    class IllustratorRepository : GenericRepository<Illustrator>, IIllustratorRepository
    {
        public IllustratorRepository(ILogger<IllustratorRepository> logger)
            : base(logger)
        {
        }

        protected override Illustrator CloneEntity(Illustrator entity)
        {
            return new()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        public Task<IEnumerable<Illustrator>> FindByNameAsync(string namePart)
        {
            Logger.LogMethodCall(namePart);

            IEnumerable<Illustrator> matchingIllustrators = Entities.Where(x => x.Name.Contains(namePart, StringComparison.InvariantCultureIgnoreCase));
            IEnumerable<Illustrator> illustrators = CloneEntities(matchingIllustrators);

            return Task.FromResult(illustrators);
        }
    }
}
