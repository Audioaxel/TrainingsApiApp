using DataLib;
using DataLib.DTOs;
using DbAccessLib.Configurations;
using DbAccessLib.Data;
using DbAccessLib.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace DbAccessLib.Module;

public static class ModuleExtensions
{
    public static void RegisterDbAccessLibService(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DatabaseDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IDatabaseRepository<TestModelDto>, DatabaseRepository>();
        services.AddAutoMapper(typeof(MapperConfig));
    }
}