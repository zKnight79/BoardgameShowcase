using BoardgameShowcase.Common;
using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Entity.Enumeration;
using BoardgameShowcase.Repository.GraphQL.Repository.Response;
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

        public async Task<IEnumerable<Boardgame>> FindAllAsync()
        {
            Logger.LogMethodCall();

            BoardgamesResponse response = await _dataAccess.Query<BoardgamesResponse>(GQL.Boardgames);

            return response.Boardgames;
        }

        public async Task<Boardgame?> FindByIdAsync(string boardgameId)
        {
            Logger.LogMethodCall(boardgameId);

            BoardgameResponse response = await _dataAccess.Query<BoardgameResponse>(GQL.Boardgame, new { boardgameId });

            return response.Boardgame;
        }

        public async Task<string?> InsertAsync(Boardgame boardgame)
        {
            Logger.LogMethodCall(boardgame);

            BoardgameResponse response = await _dataAccess.Mutation<BoardgameResponse>(GQL.BoardgameCreate, boardgame);

            return response.Boardgame?.Id;
        }

        public async Task<bool> UpdateAsync(Boardgame boardgame)
        {
            Logger.LogMethodCall(boardgame);

            BoardgameResponse response = await _dataAccess.Mutation<BoardgameResponse>(GQL.BoardgameUpdate, boardgame);

            return response.Boardgame is not null;
        }

        public async Task<bool> DeleteByIdAsync(string boardgameId)
        {
            Logger.LogMethodCall(boardgameId);

            BoardgameResponse response = await _dataAccess.Mutation<BoardgameResponse>(GQL.BoardgameDelete, new { boardgameId });

            return response.Boardgame is not null;
        }

        public async Task<IEnumerable<Boardgame>> FindByTitleAsync(string titlePart)
        {
            Logger.LogMethodCall(titlePart);

            BoardgamesResponse response = await _dataAccess.Query<BoardgamesResponse>(GQL.BoardgamesByTitle, new { titlePart });

            return response.Boardgames;
        }

        public async Task<IEnumerable<Boardgame>> FindByAuthorIdAsync(string authorId)
        {
            Logger.LogMethodCall(authorId);

            BoardgamesResponse response = await _dataAccess.Query<BoardgamesResponse>(GQL.BoardgamesByAuthor, new { authorId });

            return response.Boardgames;
        }

        public async Task<IEnumerable<Boardgame>> FindByIllustratorIdAsync(string illustratorId)
        {
            Logger.LogMethodCall(illustratorId);

            BoardgamesResponse response = await _dataAccess.Query<BoardgamesResponse>(GQL.BoardgamesByIllustrator, new { illustratorId });

            return response.Boardgames;
        }

        public async Task<IEnumerable<Boardgame>> FindByPublisherIdAsync(string publisherId)
        {
            Logger.LogMethodCall(publisherId);

            BoardgamesResponse response = await _dataAccess.Query<BoardgamesResponse>(GQL.BoardgamesByPublisher, new { publisherId });

            return response.Boardgames;
        }

        public async Task<IEnumerable<Boardgame>> FindByThemeAsync(Theme theme)
        {
            Logger.LogMethodCall(theme);

            BoardgamesResponse response = await _dataAccess.Query<BoardgamesResponse>(GQL.BoardgamesByTheme, new { theme });

            return response.Boardgames;
        }

        public async Task<IEnumerable<Boardgame>> FindByMechanismAsync(Mechanism mechanism)
        {
            Logger.LogMethodCall(mechanism);

            BoardgamesResponse response = await _dataAccess.Query<BoardgamesResponse>(GQL.BoardgamesByMechanism, new { mechanism });

            return response.Boardgames;
        }

        public async Task<IEnumerable<Boardgame>> FindByCategoryAsync(Category category)
        {
            Logger.LogMethodCall(category);

            BoardgamesResponse response = await _dataAccess.Query<BoardgamesResponse>(GQL.BoardgamesByCategory, new { category });

            return response.Boardgames;
        }
    }
}
