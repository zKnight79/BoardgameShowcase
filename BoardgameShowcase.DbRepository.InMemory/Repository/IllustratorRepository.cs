﻿using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.DbRepository.Repository;
using BoardgameShowcase.Model.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.DbRepository.InMemory.Repository
{
    class IllustratorRepository : GenericRepository<Illustrator>, IIllustratorRepository
    {
        public IllustratorRepository(ILogger<IllustratorRepository> logger, IConfiguration configuration)
            : base(logger, configuration)
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
            List<Illustrator> illustrators = new();
            foreach (Illustrator illustrator in matchingIllustrators)
            {
                illustrators.Add(CloneEntity(illustrator));
            }

            return Task.FromResult<IEnumerable<Illustrator>>(illustrators);
        }
    }
}
