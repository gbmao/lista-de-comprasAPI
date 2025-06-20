using System;

namespace lista_de_comprasAPI.Dtos;

public record class ItemDto(
    int Id,
     string Name,
     string Category,
       int Quantities,
        DateOnly ExpirationDate);