using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Repository.Repository
{
    /// <summary>
    /// The repository interface to access a publisher.
    /// </summary>
    public interface IPublisherRepository : IGenericRepository<Publisher>
    {
        /// <summary>
        /// Find all publishers with <see cref="Publisher.Name"/> that contains <paramref name="namePart"/>.
        /// </summary>
        /// <param name="namePart">A part of the publisher's name to search for.</param>
        /// <returns>All matching publishers.</returns>
        Task<IEnumerable<Publisher>> FindByNameAsync(string namePart);
    }
}
