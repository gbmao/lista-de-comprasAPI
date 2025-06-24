using System;
using lista_de_comprasAPI.Data;
using lista_de_comprasAPI.Entities;
using lista_de_comprasAPI.Mapping;
using Microsoft.EntityFrameworkCore;

namespace lista_de_comprasAPI.Endpoints;

public static class CategoryEndpoints
{
    public static RouteGroupBuilder MapCategoryEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("category");

        group.MapGet("/", async (Lista_de_comprasContext dbContext) =>
        await dbContext.Categories
                       .Select(category => category.ToDto())
                       .AsNoTracking()
                       .ToListAsync());
        return group;
    }
}
