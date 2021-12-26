using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Entity.Enumeration;
using BoardgameShowcase.Repository.Repository;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.Repository.InMemory.Repository
{
    class BoardgameRepository : GenericRepository<Boardgame>, IBoardgameRepository
    {
        public BoardgameRepository(ILogger<BoardgameRepository> logger, IDataAccess<Boardgame> dataAccess)
            : base(logger, dataAccess)
        {
        }

        public Task<IEnumerable<Boardgame>> FindByTitleAsync(string titlePart)
        {
            Logger.LogMethodCall(titlePart);

            IEnumerable<Boardgame> boardgames = DataAccess.QueryEntities(x => x.Title.Contains(titlePart, StringComparison.InvariantCultureIgnoreCase));

            return Task.FromResult(boardgames);
        }

        public Task<IEnumerable<Boardgame>> FindByAuthorIdAsync(string authorId)
        {
            Logger.LogMethodCall(authorId);

            IEnumerable<Boardgame> boardgames = DataAccess.QueryEntities(x => x.AuthorId == authorId);

            return Task.FromResult(boardgames);
        }

        public Task<IEnumerable<Boardgame>> FindByIllustratorIdAsync(string illustratorId)
        {
            Logger.LogMethodCall(illustratorId);

            IEnumerable<Boardgame> boardgames = DataAccess.QueryEntities(x => x.IllustratorId == illustratorId);

            return Task.FromResult(boardgames);
        }

        public Task<IEnumerable<Boardgame>> FindByPublisherIdAsync(string publisherId)
        {
            Logger.LogMethodCall(publisherId);

            IEnumerable<Boardgame> boardgames = DataAccess.QueryEntities(x => x.PublisherId == publisherId);

            return Task.FromResult(boardgames);
        }

        public Task<IEnumerable<Boardgame>> FindByThemeAsync(Theme theme)
        {
            Logger.LogMethodCall(theme);

            IEnumerable<Boardgame> boardgames = DataAccess.QueryEntities(x => x.Themes.Contains(theme));

            return Task.FromResult(boardgames);
        }

        public Task<IEnumerable<Boardgame>> FindByMechanismAsync(Mechanism mechanism)
        {
            Logger.LogMethodCall(mechanism);

            IEnumerable<Boardgame> boardgames = DataAccess.QueryEntities(x => x.Mechanisms.Contains(mechanism));

            return Task.FromResult(boardgames);
        }

        public Task<IEnumerable<Boardgame>> FindByCategoryAsync(Category category)
        {
            Logger.LogMethodCall(category);

            IEnumerable<Boardgame> boardgames = DataAccess.QueryEntities(x => x.Category == category);

            return Task.FromResult(boardgames);
        }
    }
}
