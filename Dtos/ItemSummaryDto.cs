using System;

namespace lista_de_comprasAPI.Dtos;

public record class ItemSummaryDto(
    
    int Id,
     string Name,
      string Category,
       int Quantities,
        DateOnly ExpirationDate
);
