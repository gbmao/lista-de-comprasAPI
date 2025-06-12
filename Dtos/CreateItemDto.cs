using System;

namespace lista_de_comprasAPI.Dtos;

public record class CreateItemDto(
     string Name,
       int Quantities,
        DateOnly ExpirationDate);
