using BoardgameShowcase.Common;
using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Repository.GraphQL.Repository.Response;
using BoardgameShowcase.Repository.Repository;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.Repository.GraphQL.Repository
{
    class AuthorRepository : Loggable<AuthorRepository>, IAuthorRepository
    {
        private readonly IDataAccess _dataAccess;
        
        public AuthorRepository(ILogger<AuthorRepository> logger, IDataAccess dataAccess)
            : base(logger)
        {
            _dataAccess = dataAccess;
        }

        public async Task<IEnumerable<Author>> FindAllAsync()
        {
            Logger.LogMethodCall();
            
            AuthorsResponse response = await _dataAccess.Query<AuthorsResponse>(GQL.Authors);

            return response.Authors;
        }

        public async Task<Author?> FindByIdAsync(string authorId)
        {
            Logger.LogMethodCall(authorId);

            AuthorResponse response = await _dataAccess.Query<AuthorResponse>(GQL.Author, new { authorId });

            return response.Author;
        }

        public async Task<string?> InsertAsync(Author author)
        {
            Logger.LogMethodCall(author);

            AuthorResponse response = await _dataAccess.Mutation<AuthorResponse>(GQL.AuthorCreate, author);

            return response.Author?.Id;
        }

        public async Task<bool> UpdateAsync(Author author)
        {
            Logger.LogMethodCall(author);

            AuthorResponse response = await _dataAccess.Mutation<AuthorResponse>(GQL.AuthorUpdate, author);

            return response.Author is not null;
        }

        public async Task<bool> DeleteByIdAsync(string authorId)
        {
            Logger.LogMethodCall(authorId);

            AuthorResponse response = await _dataAccess.Mutation<AuthorResponse>(GQL.AuthorDelete, new { authorId });

            return response.Author is not null;
        }

        public async Task<IEnumerable<Author>> FindByNameAsync(string namePart)
        {
            Logger.LogMethodCall(namePart);

            AuthorsResponse response = await _dataAccess.Query<AuthorsResponse>(GQL.AuthorsByName, new { namePart });

            return response.Authors;
        }
    }
}
