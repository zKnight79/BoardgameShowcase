using BoardgameShowcase.GraphQL.Server.GraphTypes;
using BoardgameShowcase.Repository.InMemory.Extensions;
using GraphQL.Server;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(
    (hostingContext, loggerConfiguration) =>
        loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration)
);

IServiceCollection services = builder.Services;
services.AddBoardgameShowcaseRepositoryInMemory();
services.AddSingleton<BoardgameShowcaseQuery>();
services.AddSingleton<BoardgameShowcaseMutation>();
services.AddSingleton<BoardgameShowcaseSubscription>();
services.AddSingleton<BoardgameShowcaseSchema>();
services.AddGraphQL((options, provider) =>
    {
        options.EnableMetrics = builder.Environment.IsDevelopment();
        var logger = provider.GetRequiredService<ILogger<Program>>();
        options.UnhandledExceptionDelegate = ctx => logger.LogError("{Error} occurred", ctx.OriginalException.Message);
    })
    .AddSystemTextJson()
    .AddWebSockets()
    .AddGraphTypes();

WebApplication app = builder.Build();
app.MapGet("/", () => "Welcome to the Boardgame Showcase GraphQL Server");
app.UseWebSockets();
app.UseGraphQLWebSockets<BoardgameShowcaseSchema>();
app.UseGraphQL<BoardgameShowcaseSchema>();
if (app.Environment.IsDevelopment())
{
    app.UseGraphQLAltair();
    app.UseGraphQLVoyager();
}
app.Run();
