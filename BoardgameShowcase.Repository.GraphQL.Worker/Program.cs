using BoardgameShowcase.Repository.GraphQL.Extensions;
using BoardgameShowcase.Repository.GraphQL.Worker;
using Serilog;

IHost host = Host.CreateDefaultBuilder(args)
    .UseSerilog((hostingContext, loggerConfiguration) =>
        loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration)
    )
    .ConfigureServices(services =>
    {
        services.AddBoardgameShowcaseRepositoryGraphQL();
        services.AddTransient<IJob, AuthorJob>();
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
