using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Model.Service
{
    /// <summary>
    /// The service interface to access an illustrator.
    /// </summary>
    public interface IIllustratorService : IGenericService<Illustrator>
    {
        /// <summary>
        /// Get all illustrators with <see cref="Illustrator.Name"/> that contains <paramref name="namePart"/>.
        /// </summary>
        /// <param name="namePart">A part of the illustrator's name to search for.</param>
        /// <returns>All matching illustrators.</returns>
        Task<IEnumerable<Illustrator>> GetByNameAsync(string namePart);
    }
}
