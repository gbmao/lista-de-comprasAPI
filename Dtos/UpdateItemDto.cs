using System;

namespace lista_de_comprasAPI.Dtos;

public record class UpdateItemDto(

     string Name,
       int Quantities,
        DateOnly ExpirationDate);
