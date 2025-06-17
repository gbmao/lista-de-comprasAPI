using System;
using System.Reflection.Metadata;
using lista_de_comprasAPI.Dtos;

namespace lista_de_comprasAPI.Endpoints;

public static class ProgramEndpoints
{
    private static readonly List<ItemDto> itens = [
    new (1,"Arroz","Comida cotidiana",2,new DateOnly(2030,01,30)),
    new (2,"Feijão","Comida cotidiana",1,new DateOnly(2020,05,12)),
    new (3,"Macarrão","Comida cotidiana",5,new DateOnly(2025,10,03))
 ];

    public static RouteGroupBuilder MapProgramEndpoint(this WebApplication app)
    {
        var group = app.MapGroup("itens").WithParameterValidation();

        const string itensPath = "GetItens";

        //Get /itens
        group.MapGet("/", () => itens);

        //Get /itens/1
        // trying .NameWith
        group.MapGet("{id}", (int id) =>
        {
            var item = itens.Find(item => item.Id == id);
            return item is null ? Results.NotFound() : Results.Ok(item);
        }).WithName(itensPath);

        //POST /item/1

        group.MapPost("/", (CreateItemDto newItem) =>
        {
            ItemDto item = new(
                itens.Count + 1,
                newItem.Name,
                newItem.Category,
                newItem.Quantities,
                newItem.ExpirationDate);

            itens.Add(item);

            return Results.CreatedAtRoute(itensPath, new { id = item.Id }, item);
        });

        // DELETE delete itens/id

        group.MapDelete("/{id}", (int id) =>
        {
            itens.RemoveAll(item => item.Id == id);
            return Results.NoContent();
        });

        // PUT

        group.MapPut("/{id}", (int id, UpdateItemDto updateItem) =>
        {
            var index = itens.FindIndex(item => item.Id == id);
            if (index == -1) return Results.NotFound();

            itens[index] = new ItemDto(
                id,
                updateItem.Name,
                updateItem.Category,
                updateItem.Quantities,
                updateItem.ExpirationDate
            );
            return Results.NoContent();
        });
        return group;
    }

}
