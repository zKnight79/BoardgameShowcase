using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.DbRepository.Repository;
using BoardgameShowcase.Model.Entity;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.DbRepository.InMemory.Repository
{
    class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        static AuthorRepository()
        {
            Entities.Add(new()
            {
                Id = "31709d7cb6b743adb35c9546bef3fdee",
                Name = "Antoine Bauza"
            });
            Entities.Add(new()
            {
                Id = "bdf144204fb3476aa9094f9ac5cd7112",
                Name = "Jacob Fryxelius"
            });
            Entities.Add(new()
            {
                Id = "5bf7883e49a14abebc81b38bcdcec866",
                Name = "Jamey Stegmaier"
            });
            Entities.Add(new()
            {
                Id = "1e5e9bb7d5c84bc596f73488f9c6a19c",
                Name = "Richard Garfield"
            });
            Entities.Add(new()
            {
                Id = "eb895b1f1a054b458471972587d51dc3",
                Name = "Alan R. Moon"
            });
            Entities.Add(new()
            {
                Id = "294fb4abf5d94d93b21aebff08998b3d",
                Name = "Michael Kiesling"
            });
        }
        
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
            List<Author> authors = new();
            foreach (Author author in matchingAuthors)
            {
                authors.Add(CloneEntity(author));
            }

            return Task.FromResult<IEnumerable<Author>>(authors);
        }
    }
}
