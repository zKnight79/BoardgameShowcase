using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.DbRepository.Repository;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Entity.Enumeration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.DbRepository.InMemory.Repository
{
    class BoardgameRepository : GenericRepository<Boardgame>, IBoardgameRepository
    {
        public BoardgameRepository(ILogger<BoardgameRepository> logger, IConfiguration configuration)
            : base(logger, configuration)
        {
        }

        protected override Boardgame CloneEntity(Boardgame entity)
        {
            return new()
            {
                Id = entity.Id,
                AuthorId = entity.AuthorId,
                IllustratorId = entity.IllustratorId,
                PublisherId = entity.PublisherId,
                Title = entity.Title,
                MinimumPlayerCount = entity.MinimumPlayerCount,
                MaximumPlayerCount = entity.MaximumPlayerCount,
                MinimumPlayerAge = entity.MinimumPlayerAge,
                ApproximateGameTimeInMinutes = entity.ApproximateGameTimeInMinutes,
                Themes = entity.Themes,
                Mechanisms = entity.Mechanisms,
                Category = entity.Category
            };
        }

        public Task<IEnumerable<Boardgame>> FindByTitleAsync(string titlePart)
        {
            Logger.LogMethodCall(titlePart);

            IEnumerable<Boardgame> matchingBoardgames = Entities.Where(x => x.Title.Contains(titlePart, StringComparison.InvariantCultureIgnoreCase));
            IEnumerable<Boardgame> boardgames = CloneEntities(matchingBoardgames);

            return Task.FromResult(boardgames);
        }

        public Task<IEnumerable<Boardgame>> FindByAuthorIdAsync(string authorId)
        {
            Logger.LogMethodCall(authorId);

            IEnumerable<Boardgame> matchingBoardgames = Entities.Where(x => x.AuthorId == authorId);
            IEnumerable<Boardgame> boardgames = CloneEntities(matchingBoardgames);

            return Task.FromResult(boardgames);
        }

        public Task<IEnumerable<Boardgame>> FindByIllustratorIdAsync(string illustratorId)
        {
            Logger.LogMethodCall(illustratorId);

            IEnumerable<Boardgame> matchingBoardgames = Entities.Where(x => x.IllustratorId == illustratorId);
            IEnumerable<Boardgame> boardgames = CloneEntities(matchingBoardgames);

            return Task.FromResult(boardgames);
        }

        public Task<IEnumerable<Boardgame>> FindByPublisherIdAsync(string publisherId)
        {
            Logger.LogMethodCall(publisherId);

            IEnumerable<Boardgame> matchingBoardgames = Entities.Where(x => x.PublisherId == publisherId);
            IEnumerable<Boardgame> boardgames = CloneEntities(matchingBoardgames);

            return Task.FromResult(boardgames);
        }

        public Task<IEnumerable<Boardgame>> FindByThemeAsync(Theme theme)
        {
            Logger.LogMethodCall(theme);

            IEnumerable<Boardgame> matchingBoardgames = Entities.Where(x => x.Themes.Contains(theme));
            IEnumerable<Boardgame> boardgames = CloneEntities(matchingBoardgames);

            return Task.FromResult(boardgames);
        }

        public Task<IEnumerable<Boardgame>> FindByMechanismAsync(Mechanism mechanism)
        {
            Logger.LogMethodCall(mechanism);

            IEnumerable<Boardgame> matchingBoardgames = Entities.Where(x => x.Mechanisms.Contains(mechanism));
            IEnumerable<Boardgame> boardgames = CloneEntities(matchingBoardgames);

            return Task.FromResult(boardgames);
        }

        public Task<IEnumerable<Boardgame>> FindByCategoryAsync(Category category)
        {
            Logger.LogMethodCall(category);

            IEnumerable<Boardgame> matchingBoardgames = Entities.Where(x => x.Category == category);
            IEnumerable<Boardgame> boardgames = CloneEntities(matchingBoardgames);

            return Task.FromResult(boardgames);
        }
    }
}
