using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Repository.Repository
{
    /// <summary>
    /// The repository interface to access an author.
    /// </summary>
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        /// <summary>
        /// Find all authors with <see cref="Author.Name"/> that contains <paramref name="namePart"/>.
        /// </summary>
        /// <param name="namePart">A part of the author's name to search for.</param>
        /// <returns>All matching authors.</returns>
        Task<IEnumerable<Author>> FindByNameAsync(string namePart);
    }
}
