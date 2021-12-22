using BoardgameShowcase.Common.Extensions;
using BoardgameShowcase.DbRepository.Repository;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;
using Microsoft.Extensions.Logging;

namespace BoardgameShowcase.DbRepository.Service
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
