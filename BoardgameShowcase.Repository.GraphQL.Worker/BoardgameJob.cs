using BoardgameShowcase.Common;
using BoardgameShowcase.Common.Utility;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Entity.Enumeration;
using BoardgameShowcase.Model.Service;
using Serilog.Sinks.SystemConsole.Themes;

namespace BoardgameShowcase.Repository.GraphQL.Worker
{
    class BoardgameJob : Loggable<BoardgameJob>, IJob
    {
        private readonly IBoardgameService _boardgameService;

        public BoardgameJob(ILogger<BoardgameJob> logger, IBoardgameService boardgameService)
            : base(logger)
        {
            _boardgameService = boardgameService;
        }

        public async Task DoJob()
        {
            await GetAllBoardgames();
            await GetOneBoardgame("e62ba15355724c54ba31639eee5755f3");
            await GetOneBoardgame("azertyuiopqsdfghjklmwxcvbn123456");
            await GetBoardgamesByTitle("te");
            await GetBoardgamesByTitle("ing");
            await AddBoardgame(
                "Les Aventuriers du Rail - Europe",
                "eb895b1f1a054b458471972587d51dc3",
                "afca2c0c57664311af12ebf09daf70dd",
                "3ceb6ddd724543c786a654e7c5a1d13e",
                2,
                5,
                8,
                45,
                Category.Racing,
                EnumerableUtil.From(Theme.Trains, Theme.Europe),
                EnumerableUtil.From(Mechanism.Collection, Mechanism.Secret_Objectives)
            );
            await UpdateBoardgame("427d038416be4f5e84be0782264649a6", "Les Aventuriers du Rail - U.S.A.");
            await DeleteBoardgame("9310639a9862457d8b8f5b7c45d1774c");
        }

        private async Task GetAllBoardgames()
        {
            IEnumerable<Boardgame> boardgames = await _boardgameService.GetAllAsync();
            Logger.LogInformation($"{boardgames.Count()} boardgame(s) found");
            foreach (Boardgame boardgame in boardgames)
            {
                Logger.LogInformation($"Boardgame : Id = {boardgame.Id}, Title = {boardgame.Title}");
            }
        }
        private async Task GetOneBoardgame(string boardgameId)
        {
            Logger.LogInformation($"Try getting boardgame with id = {boardgameId}");
            Boardgame? boardgame = await _boardgameService.GetByIdAsync(boardgameId);
            if (boardgame is null)
            {
                Logger.LogInformation("Boardgame not found");
            }
            else
            {
                Logger.LogInformation($"Boardgame found : Id = {boardgame.Id}, Title = {boardgame.Title}");
            }
        }
        private async Task GetBoardgamesByTitle(string titlePart)
        {
            Logger.LogInformation($"Try getting boardgame with title like {titlePart}");
            IEnumerable<Boardgame> boardgames = await _boardgameService.GetByTitleAsync(titlePart);
            Logger.LogInformation($"{boardgames.Count()} boardgame(s) found");
            foreach (Boardgame boardgame in boardgames)
            {
                Logger.LogInformation($"Boardgame : Id = {boardgame.Id}, Title = {boardgame.Title}");
            }
        }
        private async Task AddBoardgame(
            string title,
            string authorId,
            string illustratorId,
            string publisherId,
            int minimumPlayerCount,
            int maximumPlayerCount,
            int minimumPlayerAge,
            int approximateGameTimeInMinutes,
            Category category,
            IEnumerable<Theme> themes,
            IEnumerable<Mechanism> mechanisms
        )
        {
            Logger.LogInformation($"Try adding Boardgame with title = {title}");
            Boardgame boardgame = new()
            {
                Title = title,
                AuthorId = authorId,
                IllustratorId = illustratorId,
                PublisherId = publisherId,
                MinimumPlayerCount = minimumPlayerCount,
                MaximumPlayerCount = maximumPlayerCount,
                MinimumPlayerAge = minimumPlayerAge,
                ApproximateGameTimeInMinutes = approximateGameTimeInMinutes,
                Category = category,
                Themes = themes,
                Mechanisms = mechanisms
            };
            Boardgame? added = await _boardgameService.SaveAsync(boardgame);
            if (added is null)
            {
                Logger.LogInformation("Boardgame not created");
            }
            else
            {
                Logger.LogInformation($"Boardgame created : Id = {added.Id}, Title = {added.Title}");
            }
        }
        private async Task UpdateBoardgame(string id, string newTitle)
        {
            Logger.LogInformation($"Try updating Boardgame with id = {id} to new title = {newTitle}");
            Boardgame? boardgame = await _boardgameService.GetByIdAsync(id);
            if(boardgame is not null)
            {
                boardgame.Title = newTitle;
                Boardgame? updated = await _boardgameService.SaveAsync(boardgame);
                if (updated is null)
                {
                    Logger.LogInformation("Boardgame not updated");
                }
                else
                {
                    Logger.LogInformation($"Boardgame updated : Id = {updated.Id}, Title = {updated.Title}");
                }
            }
        }
        private async Task DeleteBoardgame(string id)
        {
            Logger.LogInformation($"Try deleting Boardgame with id = {id}");
            Boardgame? removed = await _boardgameService.RemoveByIdAsync(id);
            if (removed is null)
            {
                Logger.LogInformation("Boardgame not removed");
            }
            else
            {
                Logger.LogInformation($"Boardgame removed : Id = {removed.Id}, Title = {removed.Title}");
            }
        }
    }
}
