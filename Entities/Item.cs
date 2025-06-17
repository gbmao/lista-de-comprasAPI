using System;

namespace lista_de_comprasAPI.Entities;

public class Item
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Category { get; set; }
    public required int Quantities { get; set; }
    public DateOnly ExpirationDate { get; set; }
    public  Category? CategoryId { get; set; }
}
