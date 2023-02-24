using WebApiLib.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WebApiLib.Options;
using Microsoft.Extensions.Configuration;
using DbAccessLib.Module;
using WebApiLib.Endpoints;

namespace WebApiLib;

public static class Startup
{
    public static void BuildWebApi(string[] args)
    {
        var config = ApiConfiguration.Configure(args);

        var builder = WebApplication.CreateBuilder(ApiConfiguration.GetBuildingArgs(config));


        string connectionString = builder.Configuration.GetConnectionString("DatabaseTest");
        builder.Services.RegisterDbAccessLibService(connectionString);
        
        builder.Services.Configure<ApiOptions>(config.GetSection("ApiOptions"));
        builder.Services.Configure<DatabaseOptions>(config.GetSection("DatabaseOptions"));
        

        var app = builder.Build();

        app.MapGeneralEndpoints();

        // Testing
        app.MapGet("/", () => connectionString);

        app.Run();
    }

    // Testing
    private static string Test(WebApplication app)
    {
        var options = app.Services.GetRequiredService<IOptions<ApiOptions>>();
        return options.Value.CurrentUrl;
    }
}
