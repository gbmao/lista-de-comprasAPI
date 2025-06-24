using System;
using System.Reflection.Metadata;
using lista_de_comprasAPI.Data;
using lista_de_comprasAPI.Dtos;
using lista_de_comprasAPI.Entities;
using lista_de_comprasAPI.Mapping;
using Microsoft.EntityFrameworkCore;

namespace lista_de_comprasAPI.Endpoints;

public static class ProgramEndpoints
{
    const string itensPath = "GetItens";

    public static RouteGroupBuilder MapProgramEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("itens").WithParameterValidation();

        

        //Get /itens
        group.MapGet("/", (Lista_de_comprasContext dbContext) => 
            dbContext.Items
                     .Include(item => item.Category)
                     .Select(item => item.ToItemSummaryDto())
                     .AsNoTracking());

        //Get /itens/1
        // trying .NameWith
        group.MapGet("{id}", (int id, Lista_de_comprasContext dbContext) =>
        {
            //var item = itens.Find(item => item.Id == id);
            Item? item = dbContext.Items.Find(id);

            return item is null ? Results.NotFound() : Results.Ok(item.ToItemDetailsDto());
        }).WithName(itensPath);

        //POST /item/1

        group.MapPost("/", (CreateItemDto newItem, Lista_de_comprasContext dbContext) =>
        {
            //Verificar se já existe item com mesmo nome
            // if (dbContext.Items.Any(i => i.Name.Equals(newItem.Name, StringComparison.OrdinalIgnoreCase)))
            if (dbContext.Items.Any(i => i.Name.ToLower() == newItem.Name.ToLower()))
            {
                return Results.BadRequest($"O item '{newItem.Name} já existe na lista");
            }

            Item item = newItem.ToEntity();

            dbContext.Items.Add(item);
            dbContext.SaveChanges();

            

            return Results.CreatedAtRoute(itensPath, new { id = item.Id }, item);
        });

        // DELETE delete itens/id

        group.MapDelete("/{id}", (int id, Lista_de_comprasContext dbContext) =>
        {
            dbContext.Items
                     .Where(item => item.Id == id)
                     .ExecuteDelete();
            return Results.NoContent();
        });

        // PUT

        group.MapPut("/{id}", (int id, UpdateItemDto updateItem, Lista_de_comprasContext dbContext) =>
        {
            var existingItem = dbContext.Items.Find(id);
            if (existingItem is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingItem)
                    .CurrentValues
                    .SetValues(updateItem.ToEntity(id));

            dbContext.SaveChanges();
            return Results.NoContent();            
        });
        return group;
    }

}
