using System;

namespace lista_de_comprasAPI.Dtos;

public record class ItemDetailsDto(

        int Id,
     string Name,
      int CategoryId,
       int Quantities,
        DateOnly ExpirationDate
);
