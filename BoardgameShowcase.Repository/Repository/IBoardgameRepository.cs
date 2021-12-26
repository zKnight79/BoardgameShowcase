using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Entity.Enumeration;

namespace BoardgameShowcase.Repository.Repository
{
    public interface IBoardgameRepository : IGenericRepository<Boardgame>
    {
        Task<IEnumerable<Boardgame>> FindByTitleAsync(string titlePart);
        Task<IEnumerable<Boardgame>> FindByAuthorIdAsync(string authorId);
        Task<IEnumerable<Boardgame>> FindByIllustratorIdAsync(string illustratorId);
        Task<IEnumerable<Boardgame>> FindByPublisherIdAsync(string publisherId);
        Task<IEnumerable<Boardgame>> FindByThemeAsync(Theme theme);
        Task<IEnumerable<Boardgame>> FindByMechanismAsync(Mechanism mechanism);
        Task<IEnumerable<Boardgame>> FindByCategoryAsync(Category category);
    }
}
