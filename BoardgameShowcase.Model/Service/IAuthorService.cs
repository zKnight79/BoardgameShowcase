using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Model.Service
{
    /// <summary>
    /// The service interface to access an author.
    /// </summary>
    public interface IAuthorService : IGenericService<Author>
    {
        /// <summary>
        /// Get all authors with <see cref="Author.Name"/> that contains <paramref name="namePart"/>.
        /// </summary>
        /// <param name="namePart">A part of the author's name to search for.</param>
        /// <returns>All matching authors.</returns>
        Task<IEnumerable<Author>> GetByNameAsync(string namePart);
    }
}
