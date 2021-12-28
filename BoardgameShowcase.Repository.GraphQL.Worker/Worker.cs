using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;

namespace BoardgameShowcase.Repository.GraphQL.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly IAuthorService _authorService;

        public Worker(ILogger<Worker> logger, IHostApplicationLifetime hostApplicationLifetime, IAuthorService authorService)
        {
            _logger = logger;
            _hostApplicationLifetime = hostApplicationLifetime;
            _authorService = authorService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Task.Delay(1000, stoppingToken);
            
            await GetAllAuthors();
            await GetOneAuthor("5bf7883e49a14abebc81b38bcdcec866");
            await GetOneAuthor("azertyuiopqsdfghjklmwxcvbn123456");
            await GetAuthorsByName("li");
            await GetAuthorsByName("icha");
            await AddAuthor("Bruno Cathala");
            await UpdateAuthor("1e5e9bb7d5c84bc596f73488f9c6a19c", "Garfield le chat");
            await DeleteAuthor("31709d7cb6b743adb35c9546bef3fdee");

            _hostApplicationLifetime.StopApplication();
        }

        private async Task GetAllAuthors()
        {
            IEnumerable<Author> authors = await _authorService.GetAllAsync();
            _logger.LogInformation($"{authors.Count()} author(s) found");
            foreach (Author author in authors)
            {
                _logger.LogInformation($"Author : Id = {author.Id}, Name = {author.Name}");
            }
        }
        private async Task GetOneAuthor(string authorId)
        {
            _logger.LogInformation($"Try getting author with id = {authorId}");
            Author? author = await _authorService.GetByIdAsync(authorId);
            if (author is null)
            {
                _logger.LogInformation("Author not found");
            }
            else
            {
                _logger.LogInformation($"Author found : Id = {author.Id}, Name = {author.Name}");
            }
        }
        private async Task GetAuthorsByName(string namePart)
        {
            _logger.LogInformation($"Try getting author with name like {namePart}");
            IEnumerable<Author> authors = await _authorService.GetByNameAsync(namePart);
            _logger.LogInformation($"{authors.Count()} author(s) found");
            foreach (Author author in authors)
            {
                _logger.LogInformation($"Author : Id = {author.Id}, Name = {author.Name}");
            }
        }
        private async Task AddAuthor(string name)
        {
            _logger.LogInformation($"Try adding Author with name = {name}");
            Author author = new() { Name = name };
            Author? added = await _authorService.SaveAsync(author);
            if (added is null)
            {
                _logger.LogInformation("Author not created");
            }
            else
            {
                _logger.LogInformation($"Author created : Id = {added.Id}, Name = {added.Name}");
            }
        }
        private async Task UpdateAuthor(string id, string newName)
        {
            _logger.LogInformation($"Try updating Author with id = {id} to new name = {newName}");
            Author author = new() { Id = id, Name = newName };
            Author? updated = await _authorService.SaveAsync(author);
            if (updated is null)
            {
                _logger.LogInformation("Author not updated");
            }
            else
            {
                _logger.LogInformation($"Author updated : Id = {updated.Id}, Name = {updated.Name}");
            }
        }
        private async Task DeleteAuthor(string id)
        {
            _logger.LogInformation($"Try deleting Author with id = {id}");
            Author? removed = await _authorService.RemoveByIdAsync(id);
            if (removed is null)
            {
                _logger.LogInformation("Author not removed");
            }
            else
            {
                _logger.LogInformation($"Author removed : Id = {removed.Id}, Name = {removed.Name}");
            }
        }
    }
}