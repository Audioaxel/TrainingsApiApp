using DataLib;
using DataLib.DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace WebApiLib.Endpoints;

internal static class GeneralApi

{
    internal static void MapGeneralEndpoints(this WebApplication app)
    {
        app.MapGet(pattern: "/Test/{id}", GetTest);
    }

    private static async Task<IResult> GetTest(IDatabaseRepository<TestModelDto> data, int id)
    {
        var results = await data.Get(id);
        return results is null ? Results.NotFound() : Results.Ok(results);
    }
}