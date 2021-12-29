using BoardgameShowcase.Repository.GraphQL.Extensions;
using BoardgameShowcase.Repository.GraphQL.Subscriber;
using Serilog;

IHost host = Host.CreateDefaultBuilder(args)
    .UseSerilog((hostingContext, loggerConfiguration) =>
        loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration)
    )
    .ConfigureServices(services =>
    {
        services.AddBoardgameShowcaseRepositoryGraphQLSubscriptionsOnly();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
