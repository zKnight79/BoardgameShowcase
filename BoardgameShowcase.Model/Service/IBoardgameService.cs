using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Entity.Enumeration;

namespace BoardgameShowcase.Model.Service
{
    /// <summary>
    /// The service interface to access a boardgame.
    /// </summary>
    public interface IBoardgameService : IGenericService<Boardgame>
    {
        /// <summary>
        /// Get all boardgames with <see cref="Boardgame.Title"/> that contains <paramref name="titlePart"/>.
        /// </summary>
        /// <param name="titlePart">A part of the boardgame's title to search for.</param>
        /// <returns>All matching boardgames.</returns>
        Task<IEnumerable<Boardgame>> GetByTitleAsync(string titlePart);
        /// <summary>
        /// Get all the boardgames related to an author's unique ID.
        /// </summary>
        /// <param name="authorId">The unique ID of an author.</param>
        /// <returns>All the boardgames related to the author's unique ID.</returns>
        Task<IEnumerable<Boardgame>> GetByAuthorIdAsync(string authorId);
        /// <summary>
        /// Get all the boardgames related to an author.
        /// </summary>
        /// <param name="author">The author.</param>
        /// <returns>All the boardgames related to the author.</returns>
        Task<IEnumerable<Boardgame>> GetByAuthorAsync(Author author) => GetByAuthorIdAsync(author.Id ?? string.Empty);
        /// <summary>
        /// Get all the boardgames related to an illustrator's unique ID.
        /// </summary>
        /// <param name="illustratorId">The unique ID of an illustrator.</param>
        /// <returns>All the boardgames related to the illustrator's unique ID.</returns>
        Task<IEnumerable<Boardgame>> GetByIllustratorIdAsync(string illustratorId);
        /// <summary>
        /// Get all the boardgames related to an illustrator.
        /// </summary>
        /// <param name="illustrator">The illustrator.</param>
        /// <returns>All the boardgames related to the illustrator.</returns>
        Task<IEnumerable<Boardgame>> GetByIllustratorAsync(Illustrator illustrator) => GetByIllustratorIdAsync(illustrator.Id ?? string.Empty);
        /// <summary>
        /// Get all the boardgames related to a publisher's unique ID.
        /// </summary>
        /// <param name="publisherId">The unique ID of a publisher.</param>
        /// <returns>All the boardgames related to the publisher's unique ID.</returns>
        Task<IEnumerable<Boardgame>> GetByPublisherIdAsync(string publisherId);
        /// <summary>
        /// Get all the boardgames related to a publisher.
        /// </summary>
        /// <param name="publisher">The publisher.</param>
        /// <returns>All the boardgames related to the publisher.</returns>
        Task<IEnumerable<Boardgame>> GetByPublisherAsync(Publisher publisher) => GetByPublisherIdAsync(publisher.Id ?? string.Empty);
        /// <summary>
        /// Get all the boardgames related to a theme.
        /// </summary>
        /// <param name="theme">The theme.</param>
        /// <returns>All the boardgames related to the theme.</returns>
        Task<IEnumerable<Boardgame>> GetByThemeAsync(Theme theme);
        /// <summary>
        /// Get all the boardgames related to a mechanism.
        /// </summary>
        /// <param name="mechanism">The mechanism.</param>
        /// <returns>All the boardgames related to the mechanism.</returns>
        Task<IEnumerable<Boardgame>> GetByMechanismAsync(Mechanism mechanism);
        /// <summary>
        /// Get all the boardgames related to a category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>All the boardgames related to the category.</returns>
        Task<IEnumerable<Boardgame>> GetByCategoryAsync(Category category);
    }
}
