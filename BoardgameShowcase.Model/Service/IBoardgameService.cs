using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Entity.Enumeration;

namespace BoardgameShowcase.Model.Service
{
    public interface IBoardgameService : IGenericService<Boardgame>
    {
        Task<IEnumerable<Boardgame>> GetByTitleAsync(string titlePart);
        Task<IEnumerable<Boardgame>> GetByAuthorIdAsync(string authorId);
        Task<IEnumerable<Boardgame>> GetByAuthorAsync(Author author) => GetByAuthorIdAsync(author.Id ?? string.Empty);
        Task<IEnumerable<Boardgame>> GetByIllustratorIdAsync(string illustratorId);
        Task<IEnumerable<Boardgame>> GetByIllustratorAsync(Illustrator illustrator) => GetByIllustratorIdAsync(illustrator.Id ?? string.Empty);
        Task<IEnumerable<Boardgame>> GetByPublisherIdAsync(string publisherId);
        Task<IEnumerable<Boardgame>> GetByPublisherAsync(Publisher publisher) => GetByPublisherIdAsync(publisher.Id ?? string.Empty);
        Task<IEnumerable<Boardgame>> GetByThemeAsync(Theme theme);
        Task<IEnumerable<Boardgame>> GetByMechanismAsync(Mechanism mechanism);
        Task<IEnumerable<Boardgame>> GetByCategoryAsync(Category category);
    }
}
