using BoardgameShowcase.Repository.InMemory.Extensions;
using BoardgameShowcase.Repository.InMemory.Worker;
using Serilog;

IHost host = Host.CreateDefaultBuilder(args)
    .UseSerilog((hostingContext, loggerConfiguration) =>
        loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration)
    )
    .ConfigureServices(services =>
    {
        services.AddBoardgameShowcaseRepositoryInMemory();
        services.AddTransient<IJob, AuthorJob>();
        services.AddTransient<IJob, IllustratorJob>();
        services.AddTransient<IJob, PublisherJob>();
        services.AddTransient<IJob, BoardgameJob>();
        services.AddHostedService<Worker>();
        services.AddHostedService<Subscriber>();
    })
    .Build();

await host.RunAsync();
