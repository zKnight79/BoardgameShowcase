using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using BoardgameShowcase.Repository.Repository;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.Repository.Service
{
    class AuthorService : GenericService<Author>, IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(ILogger<AuthorService> logger, IAuthorRepository authorRepository)
            : base(logger, authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Task<IEnumerable<Author>> GetByNameAsync(string namePart)
        {
            Logger.LogMethodCall(namePart);

            return _authorRepository.FindByNameAsync(namePart);
        }
    }
}
