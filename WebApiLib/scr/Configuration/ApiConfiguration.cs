using Microsoft.Extensions.Configuration;

namespace WebApiLib.Configuration;

public static class ApiConfiguration
{
    public static IConfiguration Configure(string[] args)
    {
        var preConfig = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        var allowedArgs = GetAllowedArgs(preConfig, args);

        ((IDisposable) preConfig).Dispose();

        var builder = new ConfigurationBuilder()
            .SetBasePath(Environment.CurrentDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        
        // if (validArgs.Length >= 1)
        //     builder.AddCommandLine(validArgs);

        builder = AddBuildingArgs(builder, allowedArgs);

        return builder.Build();

    }

    public static string[] GetBuildingArgs(IConfiguration config)
    {
        return config.GetSection("CommandLineArgs")
            .GetSection("BuildingArgs")
            .GetChildren()
            .Select(x => $"{x.Key}={x.Value}")
            .ToArray();
    }


    private static string[] GetAllowedArgs(IConfiguration config, string[] args)
    {
        var allowedArgs = config.GetSection("CommandLineArgs")
            .GetSection("AllowedCustomArgs")
            .GetChildren()
            .Select(x => x.Key)
            .ToArray();

        return args.Where(arg => allowedArgs.Any(val => arg.StartsWith(val)))
            .ToArray();
    }

    // Hardcoded Mist
    private static IConfigurationBuilder AddBuildingArgs(IConfigurationBuilder builder, string[] allowedArgs)
    {
        string url = allowedArgs.FirstOrDefault(a => a.StartsWith("--urls="))?.Substring(7);
        if (string.IsNullOrEmpty(url))
            return builder;

        return builder.AddInMemoryCollection(
            new Dictionary<string, string> { 
                { "CommandLineArgs:BuildingArgs:--urls", url },
                { "ApiOptions:CurrentUrl", url }
            });
    }
}