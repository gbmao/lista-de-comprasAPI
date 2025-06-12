using lista_de_comprasAPI.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<ItemDto> itens = [
   new (1,"Arroz",2,new DateOnly(2030,01,30)),
    new (2,"Feijão",1,new DateOnly(2020,05,12)),
    new (3,"Macarrão",5,new DateOnly(2025,10,03))
];

//Get /itens
app.MapGet("itens/", () => itens);

//Get /itens/1

app.MapGet("itens/{id}", (int id) =>
{
    var item = itens.Find(item => item.Id == id);
    return item;
});

//POST /item/1

app.MapPost("itens/", (CreateItemDto newItem) =>
{
    ItemDto item = new(
        itens.Count + 1,
        newItem.Name,
        newItem.Quantities,
        newItem.ExpirationDate);

    itens.Add(item);

    //return item.Id;
});

// DELETE delete itens/id

app.MapDelete("itens/{id}", (int id) =>
{
    itens.RemoveAll(item => item.Id == id);
    return Results.NoContent();
});

app.Run();
