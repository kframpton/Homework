using DataEntities.Contexts;
using Microsoft.EntityFrameworkCore;
using Serilog;
using StoriedTakeHomeWebApi.Handlers.Commands;
using StoriedTakeHomeWebApi.Handlers.Queries;
using StoriedTakeHomeWebApi.Interfaces.Commands;
using StoriedTakeHomeWebApi.Interfaces.Queries;

Directory.SetCurrentDirectory(AppContext.BaseDirectory);
IConfiguration config = WebApplication.CreateBuilder().Configuration;

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(config)
    .CreateLogger();

try
{
    Log.Information("Getting things a rockin'");
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, lc) => lc
            .Enrich.FromLogContext()
            .ReadFrom.Configuration(ctx.Configuration));

    builder.Services.AddDbContext<TardisContext>();
    builder.Services.AddScoped<IPersonCommandHandler, PersonCommandHandler>();
    builder.Services.AddScoped<IPersonQueryHandler, PersonQueryHandler>();
    builder.WebHost.UseUrls("https://localhost:7096", "http://localhost:5114");
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    app.UseExceptionHandler("/errors");
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    using IServiceScope serviceScope = app.Services.CreateScope();
    IServiceProvider services = serviceScope.ServiceProvider;
    using IServiceScope scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope();
    using TardisContext db = scope.ServiceProvider.GetRequiredService<TardisContext>();

    Log.Information("Should I fly south for the winter?");
    if (args.Contains("--migrate") || !db.Database.GetAppliedMigrations().Any())
    {
        Log.Information("Why yes, yes I should");
        db.Database.Migrate();
    }
    else
    {
        Log.Information("Definitely not, I'm quite ok with cold");
    }

    Log.Information("And away we go");
    app.Run();
}
catch (Exception ex) when (ex.GetType().Name != "HostAbortedException")
{
    Log.Error(ex, "Something really bad happened");
}
finally
{
    Log.Information("Now I lay me down to sleep...");
    Log.CloseAndFlush();
}
