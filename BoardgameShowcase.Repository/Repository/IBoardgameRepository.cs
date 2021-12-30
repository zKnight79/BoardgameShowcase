using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Entity.Enumeration;

namespace BoardgameShowcase.Repository.Repository
{
    /// <summary>
    /// The repository interface to access a boardgame.
    /// </summary>
    public interface IBoardgameRepository : IGenericRepository<Boardgame>
    {
        /// <summary>
        /// Find all boardgames with <see cref="Boardgame.Title"/> that contains <paramref name="titlePart"/>.
        /// </summary>
        /// <param name="titlePart">A part of the boardgame's title to search for.</param>
        /// <returns>All matching boardgames.</returns>
        Task<IEnumerable<Boardgame>> FindByTitleAsync(string titlePart);
        /// <summary>
        /// Find all the boardgames related to an author's unique ID.
        /// </summary>
        /// <param name="authorId">The unique ID of an author.</param>
        /// <returns>All the boardgames related to the author's unique ID.</returns>
        Task<IEnumerable<Boardgame>> FindByAuthorIdAsync(string authorId);
        /// <summary>
        /// Find all the boardgames related to an illustrator's unique ID.
        /// </summary>
        /// <param name="illustratorId">The unique ID of an illustrator.</param>
        /// <returns>All the boardgames related to the illustrator's unique ID.</returns>
        Task<IEnumerable<Boardgame>> FindByIllustratorIdAsync(string illustratorId);
        /// <summary>
        /// Find all the boardgames related to a publisher's unique ID.
        /// </summary>
        /// <param name="publisherId">The unique ID of a publisher.</param>
        /// <returns>All the boardgames related to the publisher's unique ID.</returns>
        Task<IEnumerable<Boardgame>> FindByPublisherIdAsync(string publisherId);
        /// <summary>
        /// Find all the boardgames related to a theme.
        /// </summary>
        /// <param name="theme">The theme.</param>
        /// <returns>All the boardgames related to the theme.</returns>
        Task<IEnumerable<Boardgame>> FindByThemeAsync(Theme theme);
        /// <summary>
        /// Find all the boardgames related to a mechanism.
        /// </summary>
        /// <param name="mechanism">The mechanism.</param>
        /// <returns>All the boardgames related to the mechanism.</returns>
        Task<IEnumerable<Boardgame>> FindByMechanismAsync(Mechanism mechanism);
        /// <summary>
        /// Find all the boardgames related to a category.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>All the boardgames related to the category.</returns>
        Task<IEnumerable<Boardgame>> FindByCategoryAsync(Category category);
    }
}
