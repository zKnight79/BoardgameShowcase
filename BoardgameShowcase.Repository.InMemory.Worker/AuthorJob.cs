using BoardgameShowcase.Common;
using BoardgameShowcase.Model.Entity;
using BoardgameShowcase.Model.Service;

namespace BoardgameShowcase.Repository.InMemory.Worker
{
    class AuthorJob : Loggable<AuthorJob>, IJob
    {
        private readonly IAuthorService _authorService;

        public AuthorJob(ILogger<AuthorJob> logger, IAuthorService authorService)
            : base(logger)
        {
            _authorService = authorService;
        }

        public async Task DoJob()
        {
            await GetAllAuthors();
            await GetOneAuthor("5bf7883e49a14abebc81b38bcdcec866");
            await GetOneAuthor("azertyuiopqsdfghjklmwxcvbn123456");
            await GetAuthorsByName("li");
            await GetAuthorsByName("icha");
            await AddAuthor("Bruno Cathala");
            await UpdateAuthor("1e5e9bb7d5c84bc596f73488f9c6a19c", "Garfield le chat");
            await DeleteAuthor("31709d7cb6b743adb35c9546bef3fdee");
        }

        private async Task GetAllAuthors()
        {
            IEnumerable<Author> authors = await _authorService.GetAllAsync();
            Logger.LogInformation($"{authors.Count()} author(s) found");
            foreach (Author author in authors)
            {
                Logger.LogInformation($"Author : Id = {author.Id}, Name = {author.Name}");
            }
        }
        private async Task GetOneAuthor(string authorId)
        {
            Logger.LogInformation($"Try getting author with id = {authorId}");
            Author? author = await _authorService.GetByIdAsync(authorId);
            if (author is null)
            {
                Logger.LogInformation("Author not found");
            }
            else
            {
                Logger.LogInformation($"Author found : Id = {author.Id}, Name = {author.Name}");
            }
        }
        private async Task GetAuthorsByName(string namePart)
        {
            Logger.LogInformation($"Try getting author with name like {namePart}");
            IEnumerable<Author> authors = await _authorService.GetByNameAsync(namePart);
            Logger.LogInformation($"{authors.Count()} author(s) found");
            foreach (Author author in authors)
            {
                Logger.LogInformation($"Author : Id = {author.Id}, Name = {author.Name}");
            }
        }
        private async Task AddAuthor(string name)
        {
            Logger.LogInformation($"Try adding Author with name = {name}");
            Author author = new() { Name = name };
            Author? added = await _authorService.SaveAsync(author);
            if (added is null)
            {
                Logger.LogInformation("Author not created");
            }
            else
            {
                Logger.LogInformation($"Author created : Id = {added.Id}, Name = {added.Name}");
            }
        }
        private async Task UpdateAuthor(string id, string newName)
        {
            Logger.LogInformation($"Try updating Author with id = {id} to new name = {newName}");
            Author author = new() { Id = id, Name = newName };
            Author? updated = await _authorService.SaveAsync(author);
            if (updated is null)
            {
                Logger.LogInformation("Author not updated");
            }
            else
            {
                Logger.LogInformation($"Author updated : Id = {updated.Id}, Name = {updated.Name}");
            }
        }
        private async Task DeleteAuthor(string id)
        {
            Logger.LogInformation($"Try deleting Author with id = {id}");
            Author? removed = await _authorService.RemoveByIdAsync(id);
            if (removed is null)
            {
                Logger.LogInformation("Author not deleted");
            }
            else
            {
                Logger.LogInformation($"Author deleted : Id = {removed.Id}, Name = {removed.Name}");
            }
        }
    }
}
