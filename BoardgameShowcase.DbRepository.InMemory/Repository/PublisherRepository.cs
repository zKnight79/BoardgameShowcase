﻿using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.DbRepository.Repository;
using BoardgameShowcase.Model.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.DbRepository.InMemory.Repository
{
    class PublisherRepository : GenericRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(ILogger<PublisherRepository> logger, IConfiguration configuration)
            : base(logger, configuration)
        {
        }

        protected override Publisher CloneEntity(Publisher entity)
        {
            return new()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }

        public Task<IEnumerable<Publisher>> FindByNameAsync(string namePart)
        {
            Logger.LogMethodCall(namePart);

            IEnumerable<Publisher> matchingPublishers = Entities.Where(x => x.Name.Contains(namePart, StringComparison.InvariantCultureIgnoreCase));
            List<Publisher> publishers = new();
            foreach (Publisher publisher in matchingPublishers)
            {
                publishers.Add(CloneEntity(publisher));
            }

            return Task.FromResult<IEnumerable<Publisher>>(publishers);
        }
    }
}
