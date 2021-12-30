using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Model.Service
{
    /// <summary>
    /// The service interface to access a publisher.
    /// </summary>
    public interface IPublisherService : IGenericService<Publisher>
    {
        /// <summary>
        /// Get all publishers with <see cref="Publisher.Name"/> that contains <paramref name="namePart"/>.
        /// </summary>
        /// <param name="namePart">A part of the publisher's name to search for.</param>
        /// <returns>All matching publishers.</returns>
        Task<IEnumerable<Publisher>> GetByNameAsync(string namePart);
    }
}
