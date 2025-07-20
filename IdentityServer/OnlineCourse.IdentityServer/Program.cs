using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineCourse.IdentityServer;
using OnlineCourse.IdentityServer.Data;
using OnlineCourse.IdentityServer.Models;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}")
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(ctx.Configuration));

    var app = builder
        .ConfigureServices()
        .ConfigurePipeline();

    // this seeding is only for the template to bootstrap the DB and users.
    // in production you will likely want a different approach.
    //if (args.Contains("/seed"))
    //{
    //    Log.Information("Seeding database...");
    //    SeedData.EnsureSeedData(app);
    //    Log.Information("Done seeding database. Exiting.");
    //    return;
    //}

    using(var scope = app.Services.CreateScope())
    {
        var serviceProvider = scope.ServiceProvider;

        var applicationDbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
        applicationDbContext.Database.Migrate();

        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        if (!userManager.Users.Any())
        {
            userManager.CreateAsync(new
                ApplicationUser
            {
                UserName = "ferhatcakmakoglu",
                Email = "ferhat@gmail.com",
                City = "Zonguldak"
            }, "Password12*").Wait();
        }
    }

    app.Run();
}
catch (Exception ex) when (ex is not HostAbortedException)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}