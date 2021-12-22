using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.DbRepository.Repository
{
    public interface IIllustratorRepository : IGenericRepository<Illustrator>
    {
        Task<IEnumerable<Illustrator>> FindByNameAsync(string namePart);
    }
}
