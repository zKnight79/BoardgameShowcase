using BoardgameShowcase.Repository.InMemory.Extensions;
using Serilog;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(
    (hostingContext, loggerConfiguration) =>
        loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration)
);

IServiceCollection services = builder.Services;
services.AddRazorPages();
services.AddServerSideBlazor();
services.AddBoardgameShowcaseRepositoryInMemory();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
