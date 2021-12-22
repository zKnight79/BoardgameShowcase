using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.DbRepository.Repository;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Entity.Enumeration;
using BoardgameShowcase.Model.Service;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.DbRepository.Service
{
    class BoardgameService : GenericService<Boardgame>, IBoardgameService
    {
        private readonly IBoardgameRepository _boardgameRepository;
        
        public BoardgameService(ILogger<BoardgameService> logger, IBoardgameRepository boardgameRepository)
            : base(logger, boardgameRepository)
        {
            _boardgameRepository = boardgameRepository;
        }

        public Task<IEnumerable<Boardgame>> GetByTitleAsync(string titlePart)
        {
            Logger.LogMethodCall(titlePart);

            return _boardgameRepository.FindByTitleAsync(titlePart);
        }

        public Task<IEnumerable<Boardgame>> GetByAuthorIdAsync(string authorId)
        {
            Logger.LogMethodCall(authorId);

            return _boardgameRepository.FindByAuthorIdAsync(authorId);
        }

        public Task<IEnumerable<Boardgame>> GetByIllustratorIdAsync(string illustratorId)
        {
            Logger.LogMethodCall(illustratorId);

            return _boardgameRepository.FindByIllustratorIdAsync(illustratorId);
        }

        public Task<IEnumerable<Boardgame>> GetByPublisherIdAsync(string publisherId)
        {
            Logger.LogMethodCall(publisherId);

            return _boardgameRepository.FindByPublisherIdAsync(publisherId);
        }

        public Task<IEnumerable<Boardgame>> GetByThemeAsync(Theme theme)
        {
            Logger.LogMethodCall(theme);

            return _boardgameRepository.FindByThemeAsync(theme);
        }

        public Task<IEnumerable<Boardgame>> GetByMechanismAsync(Mechanism mechanism)
        {
            Logger.LogMethodCall(mechanism);

            return _boardgameRepository.FindByMechanismAsync(mechanism);
        }

        public Task<IEnumerable<Boardgame>> GetByCategoryAsync(Category category)
        {
            Logger.LogMethodCall(category);

            return _boardgameRepository.FindByCategoryAsync(category);
        }
    }
}
