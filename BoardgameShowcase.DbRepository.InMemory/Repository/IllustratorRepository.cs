using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.DbRepository.Repository;
using BoardgameShowcase.Model.Entity;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.DbRepository.InMemory.Repository
{
    class IllustratorRepository : GenericRepository<Illustrator>, IIllustratorRepository
    {
        static IllustratorRepository()
        {
            Entities.Add(new()
            {
                Id = "a48e861f73294ede862408b7a71c3df9",
                Name = "Etienne Hebinger"
            });
            Entities.Add(new()
            {
                Id = "0c67dd6252e142a8b5b010cdfc3b6dd7",
                Name = "Isaac Fryxelius"
            });
            Entities.Add(new()
            {
                Id = "714242445ee64533a1eb5b18d71f061b",
                Name = "Jakub Rozalski"
            });
            Entities.Add(new()
            {
                Id = "b916ee6e523142438ab09ef8ff11780d",
                Name = "Régis Torres"
            });
            Entities.Add(new()
            {
                Id = "afca2c0c57664311af12ebf09daf70dd",
                Name = "Julien Delval"
            });
            Entities.Add(new()
            {
                Id = "9d740aea7dbe442d9116fa2aad730222",
                Name = "Chris Quilliams"
            });
        }

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
            List<Illustrator> illustrators = new();
            foreach (Illustrator illustrator in matchingIllustrators)
            {
                illustrators.Add(CloneEntity(illustrator));
            }

            return Task.FromResult<IEnumerable<Illustrator>>(illustrators);
        }
    }
}
