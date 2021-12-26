using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using BoardgameShowcase.Repository.Repository;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.Repository.Service
{
    class IllustratorService : GenericService<Illustrator>, IIllustratorService
    {
        private readonly IIllustratorRepository _illustratorRepository;

        public IllustratorService(ILogger<IllustratorService> logger, IIllustratorRepository illustratorRepository)
            : base(logger, illustratorRepository)
        {
            _illustratorRepository = illustratorRepository;
        }

        public Task<IEnumerable<Illustrator>> GetByNameAsync(string namePart)
        {
            Logger.LogMethodCall(namePart);

            return _illustratorRepository.FindByNameAsync(namePart);
        }
    }
}
