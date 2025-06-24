using System;
using System.ComponentModel.DataAnnotations;

namespace lista_de_comprasAPI.Dtos;

public record class CreateItemDto(
    [Required][MaxLength(30)] string Name,
    int CategoryId,
      [Required] int Quantities,
        DateOnly ExpirationDate);
