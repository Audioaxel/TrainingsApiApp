using DbAccessLib.DataAccess;
using DbAccessLib.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebApiLib.Endpoints;

internal static class TestModelApi

{
    internal static void MapTestModelEndpoints(this WebApplication app)
    {
        app.MapGet(pattern: "/Test/{id}", GetTest);
    }

    private static async Task<IResult> GetTest(DatabaseDbContext context, int id)
    {
        return await context.TestModels.FindAsync(id) is TestModel testModel ? Results.Ok(testModel) : Results.NotFound();
    }

}