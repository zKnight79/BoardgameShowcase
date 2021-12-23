using BoardgameShowcase.DbRepository.InMemory.Extensions;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(
    (hostingContext, loggerConfiguration) =>
        loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration)
);

IServiceCollection services = builder.Services;
services.AddBoardgameShowcaseDbRepositoryInMemory();

WebApplication app = builder.Build();
app.MapGet("/", () => "Welcome to the Boardgame Showcase GraphQL Server");
app.Run();
