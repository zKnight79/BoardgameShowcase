using BoardgameShowcase.Common;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Entity.Enumeration;
using BoardgameShowcase.Repository.Repository;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.Repository.GraphQL.Repository
{
    class BoardgameRepository : Loggable<BoardgameRepository>, IBoardgameRepository
    {
        private readonly IDataAccess _dataAccess;

        public BoardgameRepository(ILogger<BoardgameRepository> logger, IDataAccess dataAccess)
            : base(logger)
        {
            _dataAccess = dataAccess;
        }

        public Task<IEnumerable<Boardgame>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Boardgame?> FindByIdAsync(string entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Boardgame>> FindByTitleAsync(string titlePart)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Boardgame>> FindByAuthorIdAsync(string authorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Boardgame>> FindByIllustratorIdAsync(string illustratorId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Boardgame>> FindByPublisherIdAsync(string publisherId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Boardgame>> FindByThemeAsync(Theme theme)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Boardgame>> FindByMechanismAsync(Mechanism mechanism)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Boardgame>> FindByCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<string?> InsertAsync(Boardgame entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Boardgame entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIdAsync(string entityId)
        {
            throw new NotImplementedException();
        }
    }
}
