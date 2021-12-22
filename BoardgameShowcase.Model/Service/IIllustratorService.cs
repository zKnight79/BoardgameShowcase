using BoardgameShowcase.Model.Entity;

namespace BoardgameShowcase.Model.Service
{
    public interface IIllustratorService : IGenericService<Illustrator>
    {
        Task<IEnumerable<Illustrator>> GetByNameAsync(string namePart);
    }
}
