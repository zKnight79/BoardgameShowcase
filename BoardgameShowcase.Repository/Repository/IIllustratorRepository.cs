using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Repository.Repository
{
    /// <summary>
    /// The repository interface to access an illustrator.
    /// </summary>
    public interface IIllustratorRepository : IGenericRepository<Illustrator>
    {
        /// <summary>
        /// Find all illustrators with <see cref="Illustrator.Name"/> that contains <paramref name="namePart"/>.
        /// </summary>
        /// <param name="namePart">A part of the illustrator's name to search for.</param>
        /// <returns>All matching illustrators.</returns>
        Task<IEnumerable<Illustrator>> FindByNameAsync(string namePart);
    }
}
