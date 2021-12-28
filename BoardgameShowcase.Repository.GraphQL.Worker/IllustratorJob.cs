using BoardgameShowcase.Common;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;

namespace BoardgameShowcase.Repository.GraphQL.Worker
{
    class IllustratorJob : Loggable<IllustratorJob>, IJob
    {
        private readonly IIllustratorService _illustratorService;

        public IllustratorJob(ILogger<IllustratorJob> logger, IIllustratorService illustratorService)
            : base(logger)
        {
            _illustratorService = illustratorService;
        }

        public async Task DoJob()
        {
            await GetAllIllustrators();
            await GetOneIllustrator("714242445ee64533a1eb5b18d71f061b");
            await GetOneIllustrator("azertyuiopqsdfghjklmwxcvbn123456");
            await GetIllustratorsByName("li");
            await GetIllustratorsByName("s ");
            await AddIllustrator("Miguel Coimbra");
            await UpdateIllustrator("b916ee6e523142438ab09ef8ff11780d", "Régis Laspales");
            await DeleteIllustrator("0c67dd6252e142a8b5b010cdfc3b6dd7");
        }

        private async Task GetAllIllustrators()
        {
            IEnumerable<Illustrator> illustrators = await _illustratorService.GetAllAsync();
            Logger.LogInformation($"{illustrators.Count()} illustrator(s) found");
            foreach (Illustrator illustrator in illustrators)
            {
                Logger.LogInformation($"Illustrator : Id = {illustrator.Id}, Name = {illustrator.Name}");
            }
        }
        private async Task GetOneIllustrator(string illustratorId)
        {
            Logger.LogInformation($"Try getting illustrator with id = {illustratorId}");
            Illustrator? illustrator = await _illustratorService.GetByIdAsync(illustratorId);
            if (illustrator is null)
            {
                Logger.LogInformation("Illustrator not found");
            }
            else
            {
                Logger.LogInformation($"Illustrator found : Id = {illustrator.Id}, Name = {illustrator.Name}");
            }
        }
        private async Task GetIllustratorsByName(string namePart)
        {
            Logger.LogInformation($"Try getting illustrator with name like {namePart}");
            IEnumerable<Illustrator> illustrators = await _illustratorService.GetByNameAsync(namePart);
            Logger.LogInformation($"{illustrators.Count()} illustrator(s) found");
            foreach (Illustrator illustrator in illustrators)
            {
                Logger.LogInformation($"Illustrator : Id = {illustrator.Id}, Name = {illustrator.Name}");
            }
        }
        private async Task AddIllustrator(string name)
        {
            Logger.LogInformation($"Try adding Illustrator with name = {name}");
            Illustrator illustrator = new() { Name = name };
            Illustrator? added = await _illustratorService.SaveAsync(illustrator);
            if (added is null)
            {
                Logger.LogInformation("Illustrator not created");
            }
            else
            {
                Logger.LogInformation($"Illustrator created : Id = {added.Id}, Name = {added.Name}");
            }
        }
        private async Task UpdateIllustrator(string id, string newName)
        {
            Logger.LogInformation($"Try updating Illustrator with id = {id} to new name = {newName}");
            Illustrator illustrator = new() { Id = id, Name = newName };
            Illustrator? updated = await _illustratorService.SaveAsync(illustrator);
            if (updated is null)
            {
                Logger.LogInformation("Illustrator not updated");
            }
            else
            {
                Logger.LogInformation($"Illustrator updated : Id = {updated.Id}, Name = {updated.Name}");
            }
        }
        private async Task DeleteIllustrator(string id)
        {
            Logger.LogInformation($"Try deleting Illustrator with id = {id}");
            Illustrator? removed = await _illustratorService.RemoveByIdAsync(id);
            if (removed is null)
            {
                Logger.LogInformation("Illustrator not removed");
            }
            else
            {
                Logger.LogInformation($"Illustrator removed : Id = {removed.Id}, Name = {removed.Name}");
            }
        }
    }
}
