using System;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
namespace lista_de_comprasAPI.Data;

public static class DataExtensions
{
    public static async Task MigrateDBAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<Lista_de_comprasContext>();
    await dbContext.Database.MigrateAsync();
    }
}
