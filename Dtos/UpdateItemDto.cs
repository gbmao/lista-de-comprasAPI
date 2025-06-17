using System;
using System.ComponentModel.DataAnnotations;

namespace lista_de_comprasAPI.Dtos;

public record class UpdateItemDto(

    [Required][MaxLength(30)] string Name,
    [Required][MaxLength(30)] string Category,
      [Required] int Quantities,
        DateOnly ExpirationDate);
